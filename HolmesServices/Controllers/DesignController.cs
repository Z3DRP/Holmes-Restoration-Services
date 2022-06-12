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
    public class DesignController : Controller
    {
        // probably need to add a method to add design to session
        public IActionResult Add()
        {
            TempData["Action"] = "Add-Design";

            return View("Edit", new Design());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            TempData["Action"] = "Edit-Design";
            Design design = DesignDB.GetDesignById(id);

            if (design == null)
            {
                string e = ErrorDict.GetGeneralError2("invalidId", "design");
                Error emsg = new Error("Invalid Id", e);

                return View("AppError", emsg);
            }
            else
                return View(design);
        }
        [HttpPost]
        public IActionResult Edit(Design design)
        {
            string action = (design.Id == 0) ? "Add-Design" : "Edit-Design";
            string e = string.Empty;
            bool success = default;

            if (ModelState.IsValid)
            {
                switch (action)
                {
                    case "Add-Design":
                        success = DesignDB.AddDesign(design);
                        e = ErrorDict.GetGeneralError2("AddingErr", "design");
                        break;
                    case "Edit-Design":
                        success = DesignDB.UpdateDesign(design);
                        e = ErrorDict.GetGeneralError2("UpdateErr", "design");
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
                return View(design);
            }
        }
        public IActionResult Details(int id)
        {
            TempData["Action"] = "View-Design-Details";
            Design design = DesignDB.GetDesignById(id);

            if (design == null)
            {
                string e = ErrorDict.GetGeneralError2("retrieveErr", "design");
                Error emsg = new Error("Retrevial Error", e);

                return View("AppError", emsg);
            }
            else
                return View(design);
        }
        public IActionResult ListAll(string firstname, string lastname)
        {
            TempData["Action"] = "View-Your-Designs";
            List<Design> designs = DesignDB.GetDesignsByCustomerName(firstname, lastname);

            if (designs == null)
            {
                string e = ErrorDict.GetGeneralError2("retrieveErr", "designs");
                Error emsg = new Error("Retrevial Error", e);

                return View("AppError", emsg);
            }
            else
                return View(designs);
        }
    }
}
