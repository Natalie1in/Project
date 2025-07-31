using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Dtos;
using Project.Models;
using Project.Services;
using Project.Services.Interface;
using Project.ViewModels;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        public CustomerController(ICustomerService customerService,
            IOrderService orderService)
        {
            _customerService = customerService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            int page = 1;
            int pageSize = 3;
            var totalCount = await _customerService.GetTotalCustomerCountAsync();
            var customers = await _customerService.GetCustomerOrdersWithProductsAsync(page, pageSize);

            var viewModel = new CustomerOrderPagedViewModel
            {
                Customers = customers,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductQuantity([FromBody] UpdateOrderProductDto model)
        {
            var success = await _orderService.UpdateProductQuantityAsync(model);
            if (!success)
                return NotFound("找不到對應的訂單商品明細");

            return Ok(new { success = true, message = "數量已更新" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder([FromBody] int orderId)
        {
            var success = await _orderService.DeleteOrderAsync(orderId);
            if (!success)
                return NotFound();

            return Ok(new { success = true });
        }
    }
}
