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

        public async Task<IActionResult> Details(string id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);

            await _customerService.AddAsync(customer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductQuantity([FromBody] UpdateOrderProductDto model)
        {
            var success = await _orderService.UpdateProductQuantityAsync(model);
            if (!success)
                return NotFound("找不到對應的訂單商品明細");

            return Ok(new { success = true, message = "數量已更新" });
        }

        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _customerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
