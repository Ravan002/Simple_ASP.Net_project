﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.BookCommand.AddBookAsync
{
    public class AddBookAsyncCommandRequest : IRequest<AddBookAsyncCommandResponse>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
