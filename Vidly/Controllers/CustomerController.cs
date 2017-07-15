using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

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
            var customers = _applicationDbContext.Customers.Include(c=>c.MembershipType);// For Supporting Eager loadind for the Navigation Properties 
            //ToList() will force the EF execute the query immediately
            return View(customers.ToList());
        }

        public ActionResult Detail(int id)
        {
            var customer = _applicationDbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        #endregion ControllerActions
    }
}