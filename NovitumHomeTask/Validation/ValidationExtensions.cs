using System.Collections.Generic;
using FluentValidation.Results;
using NovitumHomeTask.Model;

namespace EasyCruitChallenge.Validation
{
    public static class ValidationExtensions
    {
        public static bool IsValid(this FilterParameters candidate, out IEnumerable<string> errors)
        {
            var validator = new FilterParametersValidator();

            var validationResult = validator.Validate(candidate);

            errors = AggregateErrors(validationResult);

            return validationResult.IsValid;
        }

        private static List<string> AggregateErrors(ValidationResult validationResult)
        {
            var errors = new List<string>();

            if (!validationResult.IsValid)
                foreach (var error in validationResult.Errors)
                    errors.Add(error.ErrorMessage);

            return errors;
        }
    }
}
