using System.Linq;

namespace BookTracker.Services
{
    public interface IRepository<EntityType, in KeyType> where EntityType:class
    {
       EntityType Create(EntityType entity);
       EntityType Delete(EntityType entity);
       EntityType Update(EntityType entity);
       EntityType FindByKey(KeyType key);
       IQueryable<EntityType> All();
       void SaveChanges();
    }
}
