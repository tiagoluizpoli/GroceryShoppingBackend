using ErrorOr;
using FluentValidation.Results;

namespace Domain.Common.Errors.BaseErrors;

public static partial class BaseErrors
{
    public static class Validation
    {
        private const string ErrorBase = "ValidationsError.";

        public static Error ValidationError(ValidationFailure error)
        {
            return Error.Validation(code: $"{ErrorBase}{error.PropertyName}", description: $"{error.ErrorMessage}");
        }
    }
}