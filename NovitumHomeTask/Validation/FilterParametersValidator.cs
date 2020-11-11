using FluentValidation;
using FluentValidation.Results;
using NovitumHomeTask.Model;

namespace EasyCruitChallenge.Validation
{
    public class FilterParametersValidator : AbstractValidator<FilterParameters>
    {
        public FilterParametersValidator()
        {
            RuleFor(m => m.ClientsMin).Must(val => val == null || val > 0).WithMessage("Can't be negative client count minimum.");
            RuleFor(m => m.PotentialMin).Must(val => val == null || val > 0).WithMessage("Can't be negative potential minimum.");
            RuleFor(m => m.TotalPopulationMin).Must(val => val == null || val > 0).WithMessage("Can't be negative total population minimum.");

            // Here we could also rewrite Low, Mid, High to an enum and add enum validation (would do so in real world project)
        }

        protected override bool PreValidate(ValidationContext<FilterParameters> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please submit a non-null model."));

                return false;
            }
            return true;
        }
    }
}
