using ErrorOr;

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
    }
}