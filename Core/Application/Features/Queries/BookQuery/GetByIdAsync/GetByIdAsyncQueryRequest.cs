﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.BookQuery.GetByIdAsync
{
    public class GetByIdAsyncQueryRequest : IRequest<GetByIdAsyncQueryResponse>
    {
        public int Id { get; set; }
    }
}
