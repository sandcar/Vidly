using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {

            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            // exemplo via hardcoded
            //var customers = GetCustomers();

            // para carregar só a lista de customers
            //var customers = _context.Customers.ToList();

            // para carregar a lista de customers + referencia a membershiptypes
            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);

            // exemplo via hardcoded
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var memberShipTypes = _context.MemberShipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {

                MemberShipTypes = memberShipTypes
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {

                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };


            // Aqui usa a mesma view do insert, de outra forma a framework irá procurar pleo comportamento default( procura por uma view de nome Edit)
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()

                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {

                _context.Customers.Add(customer);
            }else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // isto é a opção indicada nos tutoriais da microsoft, só que pode trazer problemas,
                // exemplo: Posso não querer atualizar todas as propriedades enviadas no post, ou alguem malicioso pode enviar campos para modificar
                //TryUpdateModel(customerInDb);

                // isto é mais seguro embora seja tedioso. A opção pode ser o uso de autoMapper

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;


            }
         
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
            ;
        }

        // Exemplo  hardcoded sem usar entity Framework
        //private IEnumerable<Customer> GetCustomers()
        //{

        //    return new List<Customer>
        //    {
        //        new Customer {Id=1,Name="Carlos Oliveira" },

        //        new Customer {Id=2,Name="Pedro Oliveira" },

        //        new Customer {Id=3,Name="Sandra Afonso" },

        //        new Customer {Id=4,Name="Maria Constante" }
        //    };

        //}
    }
}