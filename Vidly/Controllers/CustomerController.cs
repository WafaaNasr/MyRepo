using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        #region Initialize&&Dispose

        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerController()
        {
            _applicationDbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _applicationDbContext.Dispose();
        }

        #endregion Initialize&&Dispose

        #region ControllerActions

        public ActionResult Index()
        {
            //EF as "Deferred Executions" won't execute this line until one uses the Customers or iterates on them
            var customers = _applicationDbContext.Customers;
            //ToList() will force the EF execute the query immediately
            return View(customers.ToList());
        }

        public ActionResult Detail(int id)
        {
            if (id != 1 && id != 2)
                return HttpNotFound();
            return View(_applicationDbContext.Customers.FirstOrDefault(c => c.Id == id));
        }

        #endregion ControllerActions
    }
}