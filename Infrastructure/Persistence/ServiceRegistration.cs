using Application.Repositories;
using Application.Repositories.ReadRepositories;
using Application.Repositories.WriteRepositories;
using Domain.Entites.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Repositories.ReadRepositories;
using Persistence.Repositories.WriteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection service)
        {
            service.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BookStoreDbContext>();

            service.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            service.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();

            service.AddScoped<IBookReadRepository, BookReadRepository>();
            service.AddScoped<IBookWriteRepository, BookWriteRepository>();

            service.AddScoped<IOrderReadRepository, OrderReadRepository>();
            service.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            
            service.AddScoped<ICommonFileReadRepository, CommonFileReadRepository>();
            service.AddScoped<ICommonFileWriteRepository, CommonFileWriteRepository>();

            service.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            service.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();

            service.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
            service.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
        }
    }
}
