using EntityFramework.Exceptions.Common;
using ErrorOr;
using Npgsql;

namespace Domain.Errors.Errors.DatabaseErrors;

public static partial class DatabaseErrors
{
    public static class Entity
    {
        private const string ErrorBase = "DatabaseErrors.Entity.";

        public static Error NotFound<EntityType>(EntityType Entity)
        {
            string entityName = typeof(EntityType).Name;
            return Error.NotFound(
                code: $"{ErrorBase}NotFound.{entityName}",
                description: $"{entityName} doesn't exists");
        }

        public static List<Error> UniqueConstraint(Exception exception)
        {
            UniqueConstraintException parsedException = (UniqueConstraintException)exception;
            PostgresException parsedInnerException = (PostgresException)parsedException.InnerException;
            var errors = new List<Error>()
            {
                {
                    Error.Conflict(
                        code: $"{ErrorBase}UniqueConstraint",
                        description: $"Details: {parsedException.Message}")
                },
                {
                    Error.Conflict(
                        code: $"{ErrorBase}UniqueConstraint.{parsedInnerException.ConstraintName}",
                        description: $"Details: {parsedException.InnerException.Message}")
                }
            };
            return errors;
        }
    }
}