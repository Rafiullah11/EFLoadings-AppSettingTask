using EFLoadings_AppSettingTask.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFLoadings_AppSettingTask.Controllers
{
    public class LoadingController : Controller
    {
        private readonly AppDbContext _db;

        public LoadingController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult EagerLoding()
        {
                var customers = _db.Customers
                    .Include(c => c.Invoices)
                    .ToList();
            
            return View(customers);
        }
        public IActionResult ExplicitLoding()
        {
                var customer = _db.Customers
                    .Single(c => c.CustomerId == 1);

                _db.Entry(customer)
                    .Collection(c => c.Invoices)
                    .Load();

            return View(customer);
        }
        public IActionResult LazyLoding()
        {
                var customers = _db.Customers.ToList();
            
            return View(customers);
        }

    }
}
