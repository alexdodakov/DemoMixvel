using DemoMixvel.Provider.Two.Models;
using FluentValidation;

namespace DemoMixvel.Provider.Two.Validators;
public class ProviderTwoSearchRequestValidator : AbstractValidator<ProviderTwoSearchRequest>
{
    public ProviderTwoSearchRequestValidator()
    {
        RuleFor(x => x.Departure)
            .NotEmpty().WithMessage("Departure location is required")
            .MinimumLength(2).WithMessage("Departure location must be at least 2 characters")
            .MaximumLength(100).WithMessage("Departure location cannot exceed 100 characters")
            .Matches(@"^[a-zA-Zа-яА-Я\s-]+$").WithMessage("Departure location can only contain letters, spaces, and hyphens");

        RuleFor(x => x.Arrival)
            .NotEmpty().WithMessage("Arrival location is required")
            .MinimumLength(2).WithMessage("Arrival location must be at least 2 characters")
            .MaximumLength(100).WithMessage("Arrival location cannot exceed 100 characters")
            .Matches(@"^[a-zA-Zа-яА-Я\s-]+$").WithMessage("Arrival location can only contain letters, spaces, and hyphens")
            .NotEqual(x => x.Departure).WithMessage("Departure and arrival locations must be different");

        RuleFor(x => x.DepartureDate)
            .NotEmpty().WithMessage("Departure date is required")
            .Must(date => date > DateTime.Today).WithMessage("Departure date must be in the future");

        RuleFor(x => x.MinTimeLimit)
            .Must((model, minTimeLimit) =>
                !minTimeLimit.HasValue || minTimeLimit.Value > model.DepartureDate)
            .When(x => x.MinTimeLimit.HasValue)
            .WithMessage("Minimum time limit must be in the future and before or equal to departure date");
    }
}
