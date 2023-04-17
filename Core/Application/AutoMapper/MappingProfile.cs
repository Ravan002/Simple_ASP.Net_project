using Application.Features.Commands.BookCommand.AddBookAsync;
using Application.ViewModels;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VM_Create_Book,Book>();// viewmodeli -> entity ile eslestirmek ucun
            CreateMap<Book,VM_Create_Book>();// tersi entity->viewmodel
            CreateMap<AddBookAsyncCommandRequest,Book>();
            CreateMap<Book,AddBookAsyncCommandRequest>();
        }
    }
}
