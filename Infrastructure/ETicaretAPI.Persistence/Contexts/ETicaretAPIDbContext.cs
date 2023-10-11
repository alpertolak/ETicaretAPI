using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options) { }

        public DbSet<EntityProduct> Products { get; set; }
        public DbSet<EntityOrder> Orders { get; set; }
        public DbSet<EntityCustomer> Customers { get; set; }


        public DbSet<Domain.Entities.File> Files { get; set; }

        public DbSet<ProductImagesFile> productImagesFiles{ get; set; }

        public DbSet<InvoiceFile> InvoiceFiles{ get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //entiyler üzerinden yaılan değişiklikleri ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Track edilen verileri yakalayıp elde etmemizi sağlar. 
            var datas = ChangeTracker.Entries<EntityBase>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                } ;
            }
                
            return base.SaveChangesAsync(cancellationToken);    
        }
    }
}
