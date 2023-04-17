using Application.Repositories.WriteRepositories;
using Domain.Entites;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.WriteRepositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(BookStoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
