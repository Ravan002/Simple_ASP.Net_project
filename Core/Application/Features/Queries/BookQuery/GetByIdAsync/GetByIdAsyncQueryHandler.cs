using Application.Repositories.ReadRepositories;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.BookQuery.GetByIdAsync
{
    public class GetByIdAsyncQueryHandler : IRequestHandler<GetByIdAsyncQueryRequest, GetByIdAsyncQueryResponse>
    {
        private readonly IBookReadRepository _bookReadRepository;

        public GetByIdAsyncQueryHandler(IBookReadRepository bookReadRepository)
        {
            _bookReadRepository = bookReadRepository;
        }

        public async Task<GetByIdAsyncQueryResponse> Handle(GetByIdAsyncQueryRequest request, CancellationToken cancellationToken)
        {
            Book _book = await _bookReadRepository.GetByIdAsync(request.Id, false);
            return new()
            {
                book = _book
            };
        }
    }
}
