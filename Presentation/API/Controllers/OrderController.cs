using Application.Repositories.ReadRepositories;
using Application.Repositories.WriteRepositories;
using Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;

        public OrderController(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(VM_Create_Order vm_create_order)
        {
            if (ModelState.IsValid)
            {
            }
            var result = await _orderWriteRepository.AddAsync(new()
            {
                Addresss = vm_create_order.Addresss,
                Description = vm_create_order.Description,
                CustomerId= vm_create_order.CustomerId,
            });
            await _orderWriteRepository.SaveAsync();
            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetAsync()
        {
            return Ok(_orderReadRepository.GetAll());
        }
    }
}
