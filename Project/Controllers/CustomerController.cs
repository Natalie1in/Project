using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services.Interface;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _service.GetAllAsync();
            return View(customers);
        }

        public async Task<IActionResult> Details(string id)
        {
            var customer = await _service.GetByIdAsync(id);
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

            await _service.AddAsync(customer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(string id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);

            await _service.UpdateAsync(customer);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _service.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
