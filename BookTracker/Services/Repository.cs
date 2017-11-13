using BookTracker.Data;
using System;
using System.Linq;


namespace BookTracker.Services
{

    public class Repository<EntityType, KeyType>:IRepository<EntityType, KeyType> where EntityType:class 
    {
        private readonly IBookTrackerContext _bookTrackerContext;
        public Repository(IBookTrackerContext context)
        {
            if (!context.ContainsSetFor<EntityType, KeyType>())
                throw new InvalidOperationException($"The supplied context must contain a set for type {typeof(EntityType)} with key {typeof(KeyType)}");
            _bookTrackerContext = context;

        }

        public IQueryable<EntityType> All()
        {
            return _bookTrackerContext.Set<EntityType>();
        }

        public EntityType Create(EntityType entity)
        {
           return _bookTrackerContext.Set<EntityType>().Add(entity).Entity;
        }

        public EntityType Delete(EntityType entity)
        {
            return _bookTrackerContext.Set<EntityType>().Remove(entity).Entity;
        }

        public EntityType FindByKey(KeyType key)
        {
            return _bookTrackerContext.Set<EntityType>().Find(key);
        }

        public void SaveChanges()
        {
            _bookTrackerContext.Save();
        }

        public EntityType Update(EntityType entity)
        {
            return _bookTrackerContext.Set<EntityType>().Update(entity).Entity;
        }
    }
}
