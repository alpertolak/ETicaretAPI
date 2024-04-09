using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options) { }

        public DbSet<EntityProduct> Products { get; set; }

        public DbSet<EntityOrder> Orders { get; set; }

        public DbSet<EntityCustomer> Customers { get; set; }

        public DbSet<Domain.Entities.File> Files { get; set; }

        public DbSet<ProductImagesFile> productImagesFiles { get; set; }

        public DbSet<InvoiceFile> InvoiceFiles { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }

        public DbSet<EntityBasket> Baskets { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<EntityOrder>()
                .HasKey(b => b.Id);

            builder.Entity<EntityBasket>()
                .HasOne(b => b.Order)
                .WithOne(o => o.Basket)
                .HasForeignKey<EntityOrder>(b => b.Id);

            base.OnModelCreating(builder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //entiyler üzerinden yapılan değişiklikleri ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Track edilen verileri yakalayıp elde etmemizi sağlar. 
            var datas = ChangeTracker.Entries<EntityBase>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
