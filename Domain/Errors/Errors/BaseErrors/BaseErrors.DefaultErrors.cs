using ErrorOr;

namespace Domain.Common.Errors.BaseErrors;

public static partial class BaseErrors
{
    public static class DefaultErrors
    {
        public static Error UnhandledError => Error.Failure(
            code: "UnhandledError.InternalServerError",
            description: "An unhandled error ocurred. Please contact Teros dev team."
        );

        public static Error NullParameter = Error.Validation(code: "GlobalError.NullParameter",
            description: "You've passed a null parameter. Please provide a valid parameter for this endpoint context");
    }
}