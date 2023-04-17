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
    public class CommonFileWriteRepository : WriteRepository<CommonFile>, ICommonFileWriteRepository
    {
        public CommonFileWriteRepository(BookStoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
