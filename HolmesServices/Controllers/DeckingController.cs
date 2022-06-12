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
    public class DeckingController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            TempData["Action"] = "Add-Decking";
            return View("Edit", new Decking());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            TempData["Action"] = "Edit-Decking";
            Decking decking = DeckingDB.GetDeckingById(id);

            if (decking == null)
            {
                string e = ErrorDict.GetGeneralError2("invalidId", "decking");
                Error emsg = new Error("Invalid Id", e);

                return View("AppError", emsg);
            }
            else
                return View(decking);
        }
        [HttpPost]
        public IActionResult Edit(Decking decking)
        {
            string action = (decking.Id == 0) ? "Add-Decking" : "Edit-Decking";
            string e = string.Empty;
            bool success = default;

            if (ModelState.IsValid)
            {
                switch(action)
                {
                    case "Add-Decking":
                        success = DeckingDB.AddDecking(decking);
                        e = ErrorDict.GetGeneralError2("addErr", "decking");
                        break;
                    case "Edit-Decking":
                        success = DeckingDB.UpdateDecking(decking);
                        e = ErrorDict.GetGeneralError2("updateErr", "decking");
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
                return View(decking);
            }
        }
        public IActionResult Details(int id)
        {
            TempData["Action"] = "View-Decking-Details";
            Decking decking = DeckingDB.GetDeckingById(id);

            if (decking == null)
            {
                string e = ErrorDict.GetGeneralError2("retrieveErr", "decking");
                Error emsg = new Error("Retrevial Error", e);

                return View("AppError", emsg);
            }
            else
                return View(decking);
        }
        public IActionResult ListAll()
        {
            TempData["Action"] = "Display-Deckings";
            List<Decking> deckings = new List<Decking>();

            if (deckings.Count == 0)
            {
                string e = ErrorDict.GetGeneralError("retrieveErr", "deckings");
                Error emsg = new Error("Retrieval Error", e);

                return View("AppError", emsg);
            }
            else
                return View(deckings);
        }
    }
}
