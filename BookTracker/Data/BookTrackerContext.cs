using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookTracker.Models;

namespace BookTracker.Data
{
    public interface IBookTrackerContext {
        DbSet<EntityType> Set<EntityType>() where EntityType : class;
        bool ContainsSetFor<EntityType, KeyType>() where EntityType : class;
        void Save();
    }
    internal class BookTrackerContext : IdentityDbContext<ApplicationUser>, IBookTrackerContext
    {
        public BookTrackerContext(DbContextOptions<BookTrackerContext> options)
            : base(options)
        {
           
        }
        public virtual DbSet<Book> Book { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        bool IBookTrackerContext.ContainsSetFor<TypeOfEntity, TypeOfKey>()
        {
            if (typeof(TypeOfEntity) == typeof(Book))
                return true;
            return false;



        }

        public void Detach<TypeOfEntity>(TypeOfEntity entity) where TypeOfEntity : class
        {
            Entry(entity).State = EntityState.Deleted;
        }

        public void Save()
        {
            SaveChanges();
        }


    }
}
