using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly List<Customer> _customers = new List<Customer>
            {
                new Customer {Id=1,Name="John Smith" },
                new Customer {Id=2,Name="Mary Williams" }
            };
        public ActionResult Index()
        {

            return View(_customers);
        }
        public ActionResult Detail(int id)
        {
            if (id != 1 && id != 2)
                return HttpNotFound();
            return View(_customers.FirstOrDefault(c => c.Id == id));
        }
    }
}