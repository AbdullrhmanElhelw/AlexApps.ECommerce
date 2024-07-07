using AlexApps.ECommerce.Application.Core.Errors;
using AlexApps.ECommerce.Contracts.CQRS.Commands;
using AlexApps.ECommerce.Contracts.UnitOfWork;
using AlexApps.ECommerce.Domain.Entities.Core.Carts;
using AlexApps.ECommerce.Domain.Entities.Identity.Buyers;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace AlexApps.ECommerce.Application.Carts.CreateCart;

public sealed class CreateCardCommandHandler : ICommandHandler<CreateCardCommand>
{
    private readonly ICartRepository _cartRepository;
    private readonly UserManager<Customer> _userManager;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCardCommandHandler(ICartRepository cartRepository, UserManager<Customer> userManager, IUnitOfWork unitOfWork)
    {
        _cartRepository = cartRepository;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateCardCommand request, CancellationToken cancellationToken)
    {
        var checkUserIsExists = await _userManager.FindByIdAsync(request.UserId.ToString());

        if (checkUserIsExists is null)
            return new Result().WithError(new RecordNotFoundError("User not found"));

        var checkCartIsExists = await _cartRepository.GetByCustomerIdAsync(request.UserId);

        if (checkCartIsExists is not null)
            return new Result().WithError(new RecordIsAlreadyExists("Cart already exists"));

        var cart = Cart.Create(request.UserId);

        _cartRepository.Create(cart);

        return await _unitOfWork.SaveChangesAsync(cancellationToken) == 0
            ? new Result().WithError("Error while saving cart")
            : new Result();
    }
}