using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Controllers
{
    public class DeckingDBController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
