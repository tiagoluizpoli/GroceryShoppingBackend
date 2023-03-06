using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Database
{
    public interface IBaseRepository<EntityType> where EntityType : class
    {
        void Add(EntityType obj);
        void Delete(EntityType obj);
        void Update(EntityType obj);
        Task<EntityType?> GetById(Guid Id);
        Task<List<EntityType>> GetAll();
    }
}
