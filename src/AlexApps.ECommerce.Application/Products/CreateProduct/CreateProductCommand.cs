using AlexApps.ECommerce.Contracts.CQRS.Commands;
using FluentValidation;

namespace AlexApps.ECommerce.Application.Products.CreateProduct;

public sealed record CreateProductCommand
    (string Name,
     string? Description,
     int StoreId,
     decimal Price,
     int StockQuantity,
     decimal? VatRate) : ICommand;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .Matches("^[a-zA-Z0-9 ]*$")
            .WithMessage("Only alphanumeric characters are allowed.");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .Matches("^[a-zA-Z0-9 ]*$")
            .WithMessage("Only alphanumeric characters are allowed.");

        RuleFor(x => x.StoreId)
            .GreaterThan(0);

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Stock quantity must be greater than or equal to 0.");
    }
}