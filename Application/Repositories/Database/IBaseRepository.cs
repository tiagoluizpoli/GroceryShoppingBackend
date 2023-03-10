using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace Application.Repositories.Database
{
    public interface IBaseRepository<EntityType> where EntityType : class
    {
        Task<ErrorOr<Created>> Add(EntityType obj);
        Task<ErrorOr<Deleted>> Delete(EntityType obj);
        Task<ErrorOr<Updated>> Update(EntityType obj);
        Task<ErrorOr<EntityType?>> GetById(Guid Id);

        Task<ErrorOr<List<EntityType>>> GetAll(Expression<Func<EntityType, bool>> filter = null,
            string includeProperties = "");
    }
}