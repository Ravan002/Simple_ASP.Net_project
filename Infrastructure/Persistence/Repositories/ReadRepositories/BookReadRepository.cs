﻿using Application.Repositories.ReadRepositories;
using Domain.Entites;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.ReadRepositories
{
    public class BookReadRepository : ReadRepository<Book>, IBookReadRepository
    {
        public BookReadRepository(BookStoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
