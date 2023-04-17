using Application.Features.Commands.BookCommand.AddBookAsync;
using Application.Features.Queries.BookQuery.GetByIdAsync;
using Application.Repositories;
using Application.Repositories.ReadRepositories;
using Application.Repositories.WriteRepositories;
using Application.Storage;
using Application.ViewModels;
using AutoMapper;
using Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class BookController : ControllerBase
    {
        private string _controllerName="Book";
        private readonly IBookReadRepository _bookReadRepository;
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly IStorageService _storageService;

        private readonly ICommonFileReadRepository _commonFileReadRepository;
        private readonly ICommonFileWriteRepository _commonFileWriteRepository;

        private readonly IProductImageFileReadRepository _productImageFileReadRepository;
        private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;

        private readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;
        private readonly IInvoiceFileReadRepository _invoiceFileReadRepository;

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public BookController(
            IBookWriteRepository bookWriteRepository, 
            IBookReadRepository bookReadRepository, 
            IWebHostEnvironment webHostEnvironment, 
            ICommonFileReadRepository commonFileReadRepository, 
            ICommonFileWriteRepository commonFileWriteRepository, 
            IProductImageFileReadRepository productImageFileReadRepository, 
            IProductImageFileWriteRepository productImageFileWriteRepository, 
            IInvoiceFileWriteRepository invoiceFileWriteRepository, 
            IInvoiceFileReadRepository invoiceFileReadRepository, 
            IStorageService storageService, 
            IMediator mediator, 
            IMapper mapper)
        {
            _bookWriteRepository = bookWriteRepository;
            _bookReadRepository = bookReadRepository;
            _webHostEnvironment = webHostEnvironment;

            _commonFileReadRepository = commonFileReadRepository;
            _commonFileWriteRepository = commonFileWriteRepository;

            _productImageFileReadRepository = productImageFileReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;

            _invoiceFileWriteRepository = invoiceFileWriteRepository;
            _invoiceFileReadRepository = invoiceFileReadRepository;
            _storageService = storageService;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddBookWithMediatR([FromBody]AddBookAsyncCommandRequest addBookAsyncCommandRequest)
        {
            AddBookAsyncCommandResponse response=await _mediator.Send(addBookAsyncCommandRequest);
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddBook(VM_Create_Book vm_Create_Book)
        {
            Book book = _mapper.Map<Book>(vm_Create_Book);
            await _bookWriteRepository.AddAsync(book);
            await _bookWriteRepository.SaveAsync();
            return Ok(book);
        }

        [HttpGet("[action]")]
        public IActionResult getAllBook()
        {
            List<Book> books = _bookReadRepository.GetAll().ToList();
            return Ok(books);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            await _bookWriteRepository.RemoveByIdAsync(id);
            await _bookWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadFile()
        {
            var datas = await _storageService.UploadAsync($"resource/{_controllerName}", Request.Form.Files);
            await _productImageFileWriteRepository.AddRangeAsync(datas.Select(e => new ProductImageFile()
            {
                FileName = e.fileName,
                Path = e.path,
                Storage = _storageService.StorageName
            }).ToList());
            await _productImageFileWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]GetByIdAsyncQueryRequest getByIdAsyncQueryRequest)
        {
            GetByIdAsyncQueryResponse response =await _mediator.Send(getByIdAsyncQueryRequest);
            return Ok(response);
        }
    }
}
