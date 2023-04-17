using Application.Repositories;
using Application.Repositories.ReadRepositories;
using Domain.Entites;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ReadRepositories
{
    public class ProductImageFileReadRepository : ReadRepository<ProductImageFile>, IProductImageFileReadRepository
    {
        public ProductImageFileReadRepository(BookStoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
