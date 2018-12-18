using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tournament.Test.Domain.Services
{
    public static class ModelService

    {
        public static IEnumerable<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}