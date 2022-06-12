using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolmesServices.Models;
using HolmesServices.DataAccess;
using HolmesServices.ErrorMessages;

namespace HolmesServices.Controllers
{
    public class CustomerController : Controller
    {
        // probably need to add a method to add customer id to session
        [HttpGet]
        public IActionResult Add()
        {
            TempData["Action"] = "Add-Customer";
            return View("Edit", new Customer());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            TempData["Action"] = "Edit-Customer";
            Customer customer = CustomerDB.GetCustomer(id);

            if (customer == null)
            {
                string e = ErrorDict.GetGeneralError2("invalidId", "customer");
                Error emsg = new Error("Invalid Id", e);

                return View("AppError", emsg);
            }
            else
                return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            string action = (customer.Id == 0) ? "Add-Customer" : "Edit-Customer";
            string e = string.Empty;
            bool success = default;

            if (ModelState.IsValid)
            {
                switch (action)
                {
                    case "Add-Customer":
                        success = CustomerDB.AddCustomer(customer);
                        // incase I need an error
                        e = ErrorDict.GetGeneralError2("addErr", "customer");
                        
                        break;
                    case "Edit-Customer":
                        success = CustomerDB.UpdateCustomer(customer);
                        // incase I need an error
                        e = ErrorDict.GetGeneralError("updateErr", "customer");
                        break;
                }
                if (!success)
                {
                    Error emsg = new Error("Insertion Error", e);
                    return View("AppError", emsg);
                }
                else
                    return RedirectToAction("Index", "Home");

            }
            else
            {
                TempData["Action"] = action;
                return View(customer);
            }    
        }
        public IActionResult Details(int id)
        {
            TempData["Action"] = "View-Customer-Details";
            Customer customer = CustomerDB.GetCustomer(id);
            
            if (customer == null)
            {
                string e = ErrorDict.GetGeneralError2("retrieveErr", "customer");
                Error emsg = new Error("Retrevial Error", e);

                return View("AppError", emsg);
            }
            else
                return View(customer);

        }

        public IActionResult ListAll()
        {
            TempData["Action"] = "Display-Customers";
            List<Customer> customers = CustomerDB.GetCustomers();

            if (customers.Count == 0)
            {
                string e = ErrorDict.GetGeneralError("retrieveErr", "customers");
                Error emsg = new Error("Retrieval Error", e);

                return View("AppError", emsg);
            }
            else
                return View(customers);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Customer customer = CustomerDB.GetCustomer(id);
            TempData["Action"] = "Delete-Customer";
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            TempData["Action"] = "Delete-Customer";
            int? id = customer.Id;
            bool success = CustomerDB.DeleteCustomer(id);

            if (!success)
            {
                string e = ErrorDict.GetGeneralError2("delErr", "customer");
                Error eMsg = new Error("Deletion Error", e);
                return View("AppError", eMsg);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
