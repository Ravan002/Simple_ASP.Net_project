using Domain.Entites;
using Domain.Entites.Common;
using Domain.Entites.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BookStoreDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
            
        }
        DbSet<Book> Books { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CommonFile> CommonFiles { get; set; }
        DbSet<ProductImageFile> ProductImageFiles { get; set; }
        DbSet<InvoiceFile> InvoiceFiles { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas=ChangeTracker.Entries<BaseEntity>();

            
            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:data.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        break;

                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
