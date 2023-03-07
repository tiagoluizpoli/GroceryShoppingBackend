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
    }
}