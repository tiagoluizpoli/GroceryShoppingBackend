using ErrorOr;

namespace Domain.Errors.Errors.DatabaseErrors;

public static partial class DatabaseErrors
{
    public static class General
    {
        private const string ErrorBase = "DatabaseErrors.General.";

        public static Error DatabaseGeneralError(Exception exception)
        {
            
            return Error.Failure(
                code: $"{ErrorBase}UnmappedError",
                description: $"Details: {exception.Message}");
        }
    }
}