using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolmesServices.DataAccess;
using HolmesServices.Models;
using HolmesServices.ErrorMessages;


namespace HolmesServices.Controllers
{
    public class RailingController : Controller
    {
        public IActionResult Add()
        {
            TempData["Action"] = "Add-Railing";
            return View("Edit", new Railing());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            TempData["Action"] = "Edit-Railing";
            Railing railing = RailingDB.GetRailingById(id);

            if (railing == null)
            {
                string e = ErrorDict.GetGeneralError2("invalidId", "railing");
                Error emsg = new Error("Invalid Id", e);

                return View("AppError", emsg);
            }
            else
                return View(railing);
        }
        [HttpPost]
        public IActionResult Edit(Railing railing)
        {
            string action = (railing.Id == 0) ? "Add-Railing" : "Edit-Railing";
            string e = string.Empty;
            bool success = default;

            if (ModelState.IsValid)
            {
                switch (action)
                {
                    case "Add-Railing":
                        success = RailingDB.AddRailing(railing);
                        e = ErrorDict.GetGeneralError2("addErr", "railing");
                        break;
                    case "Edit-Railing":
                        success = RailingDB.UpdateRailing(railing);
                        e = ErrorDict.GetGeneralError2("updateErr", "railing");
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
                return View(railing);
            }
        }
        public IActionResult Details(int id)
        {
            TempData["Action"] = "View-Railing-Details";
            Railing railing = RailingDB.GetRailingById(id);

            if (railing == null)
            {
                string e = ErrorDict.GetGeneralError2("retrieveErr", "railing");
                Error emsg = new Error("Retrevial Error", e);

                return View("AppError", emsg);
            }
            else
                return View(railing);
        }
        public IActionResult ListAll()
        {
            TempData["Action"] = "Display-Railings";
            List<Railing> railings = new List<Railing>();

            if (railings.Count == 0)
            {
                string e = ErrorDict.GetGeneralError("retrieveErr", "railings");
                Error emsg = new Error("Retrieval Error", e);

                return View("AppError", emsg);
            }
            else
                return View(railings);
        }
    }
}
