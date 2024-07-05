using FluentValidation;

namespace AlexApps.ECommerce.Application.Stores.CreateStore;

internal sealed class CreateStoreCommandValidator : AbstractValidator<CreateStoreCommand>
{
    public CreateStoreCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .Matches("^[a-zA-Z0-9 ]*$")
            .WithMessage("Only alphanumeric characters and spaces are allowed.");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters.");
    }
}