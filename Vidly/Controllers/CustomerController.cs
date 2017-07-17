using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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
            var customers = _applicationDbContext.Customers.Include(c => c.MembershipType);// For Supporting Eager loadind for the Navigation Properties
            //ToList() will force the EF execute the query immediately
            return View(customers.ToList());
        }

        public ActionResult Detail(int id)
        {
            var customer = _applicationDbContext.Customers.Include(c => c.MembershipType)
                .FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public ActionResult Create()
        {
            var custViewModel = new CustomerViewModel()
            {
                MembershipTypes = _applicationDbContext.MembershipTypes.ToList()
            };
            return View("CustomerForm", custViewModel);
        }

        // ModelBinding-"Mapping The Request Form Data to the input object's props"

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerForm", new CustomerViewModel { Customer = customer, MembershipTypes = _applicationDbContext.MembershipTypes.ToList() });
            }
            if (customer.Id == 0)
                _applicationDbContext.Customers.Add(customer);
            else
            {
                Customer custInDb = _applicationDbContext.Customers.Single(c => c.Id == customer.Id);

                #region May Cause SecurityHole As it takes the props' values 

                // TryUpdateModel(custInDb, "", new string[] { "Name", "Birthdate" });

                #endregion Cause SecurityHole

                custInDb.Name = customer.Name;
                custInDb.Birthdate = customer.Birthdate;
                custInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                custInDb.MembershipTypeId = customer.MembershipTypeId;
            }
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveCustOnly(Customer customer)
        {
            return View("CustomerForm");
        }


        public ActionResult Edit(int id)
        {
            var customer = _applicationDbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _applicationDbContext.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        #endregion ControllerActions
    }
}