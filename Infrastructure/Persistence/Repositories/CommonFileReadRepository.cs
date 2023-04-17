using Application.Repositories;
using Domain.Entites;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CommonFileReadRepository : ReadRepository<CommonFile>, ICommonFileReadRepository
    {
        public CommonFileReadRepository(BookStoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
