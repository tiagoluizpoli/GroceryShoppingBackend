using EntityFramework.Exceptions.Common;
using ErrorOr;
using Npgsql;

namespace Domain.Errors.Errors.DatabaseErrors;

public static partial class DatabaseErrors
{
    public static class Entity
    {
        private const string ErrorBase = "DatabaseErrors.Entity.";

        public static Error NotFound<EntityType>(string id = "")
        {
            string entityName = typeof(EntityType).Name.Replace("Entity", "");
            string idPortion = "";
            if (!string.IsNullOrWhiteSpace(id))
            {
                idPortion = $" with the id '{id}'";
            }
            return Error.NotFound(
                code: $"{ErrorBase}NotFound.{entityName}",
                description: $"{entityName}{idPortion} doesn't exists");
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