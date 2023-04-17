using Application.Repositories.WriteRepositories;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.BookCommand.AddBookAsync
{
    public class AddBookAsyncCommandHandler : IRequestHandler<AddBookAsyncCommandRequest, AddBookAsyncCommandResponse>
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IMapper _mapper;

        public AddBookAsyncCommandHandler(IBookWriteRepository bookWriteRepository, IMapper mapper)
        {
            _bookWriteRepository = bookWriteRepository;
            _mapper = mapper;
        }

        public async Task<AddBookAsyncCommandResponse> Handle(AddBookAsyncCommandRequest request, CancellationToken cancellationToken)
        {
            Book book = _mapper.Map<Book>(request);
            bool result = await _bookWriteRepository.AddAsync(book);
            await _bookWriteRepository.SaveAsync();
            return new()
            {
                Result=result
            };
        }
    }
}
