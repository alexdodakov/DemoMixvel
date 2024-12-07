using DemoMixvel.Provider.One.Models;
using FluentValidation;

namespace DemoMixvel.Provider.One.Validators;
public class ProviderOneSearchRequestValidator : AbstractValidator<ProviderOneSearchRequest>
{
    public ProviderOneSearchRequestValidator()
    {
        RuleFor(x => x.From)
            .NotEmpty().WithMessage("Starting point is required")
            .MinimumLength(2).WithMessage("Starting point must be at least 2 characters")
            .MaximumLength(100).WithMessage("Starting point cannot exceed 100 characters")
            .Matches(@"^[a-zA-Zа-яА-Я\s-]+$").WithMessage("Starting point can only contain letters, spaces, and hyphens");

        RuleFor(x => x.To)
            .NotEmpty().WithMessage("Destination point is required")
            .MinimumLength(2).WithMessage("Destination point must be at least 2 characters")
            .MaximumLength(100).WithMessage("Destination point cannot exceed 100 characters")
            .Matches(@"^[a-zA-Zа-яА-Я\s-]+$").WithMessage("Destination point can only contain letters, spaces, and hyphens");

        RuleFor(x => x.DateFrom)
            .NotEmpty().WithMessage("Start date is required")
            .Must(date => date > DateTime.Today).WithMessage("Start date must be in the future");

        RuleFor(x => x.DateTo)
            .Must((model, dateTo) =>
                !dateTo.HasValue ||
                dateTo.Value > model.DateFrom)
            .When(x => x.DateTo.HasValue)
            .WithMessage("End date must be after start date");

        // Validate 'MaxPrice' field (if provided)
        RuleFor(x => x.MaxPrice)
            .GreaterThan(0).When(x => x.MaxPrice.HasValue)
            .WithMessage("Maximum price must be greater than zero");
    }
}