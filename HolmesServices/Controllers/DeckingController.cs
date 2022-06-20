using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HolmesServices.DataAccess;
using HolmesServices.Models;
using HolmesServices.ViewModels;
using HolmesServices.ErrorMessages;
using HolmesServices.Models.DTOs;
using HolmesServices.Models.Grids;
using HolmesServices.Models.ExtensionMethods;
using HolmesServices.DataAccess.Repositories;
using HolmesServices.Models.DomainModels;
using HolmesServices.Models.RouteDictionaries;

namespace HolmesServices.Controllers
{
    public class DeckingController : Controller
    {
        private HolmesStoreUnitOfWork data { get; set; }
        private DeckingController(HolmesContext hctx) => data = new HolmesStoreUnitOfWork(hctx);
        [HttpGet]
        public IActionResult Add()
        {
            // this adds selected decking to myDesign session
            return View(); 
        }
        public ViewResult Details(int id)
        {
            var deck = data.Decks.Get(new QueryOptions<Decking>
            {
                Includes = "Type, Group",
                Where = d => d.Id == id
            });
            return View(deck);
        }
        public ViewResult List(DeckingGridDTO values)
        {
            // get string builder which loads route segment values and stores them
            // in them in the session
            var builder = new DeckingGridBuilder(HttpContext.Session, values,
                defaultSortField: nameof(Decking.Name));

            // create options for querying authors OrderBy depends on vlaue in sortfield route
            var options = new DeckingQueryOptions
            {
                Includes = "Type, Group",
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };

            //call sortfilter method of queryoptions obj and pass in the builder obj
            // it uses the route information and the properties of builder obj
            //to add osrt and fileter options to the query expression
            options.SortFilter(builder);

            // create view model and add page of decks data, data for drop-downs
            // the current route and the total number of pages
            var deckViewModel = new DeckListViewModel
            {
                Decks = data.Decks.List(options),
                Types = data.DeckTypes.List(new QueryOptions<Deck_Type>
                { OrderBy = t => t.Type }),
                Groups = data.Groups.List(new QueryOptions<Price_Groups>
                { OrderBy = g => g.Group_Name }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Decks.Count)
            };

            return View(deckViewModel);
        }
        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            // get current route segments from session
            var builder = new DeckingGridBuilder(HttpContext.Session);

            // clear or update filter route segment values if update get type data
            // from database so can add type name slug to type filter value
            if (clear)
                builder.ClearFilterSegments();
            else
            {
                var type = data.DeckTypes.Get(filter[0].ToInt());
                builder.CurrentRoute.PageNumber = 1;
                builder.LoadFilterSegments(filter, type);
            }
            // save route data back to session and redirect to Decking/List action method
            // passing dictionary of route segment values to build url
            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }
        [HttpPost]
        public RedirectToActionResult PageSize(int pagesize)
        {
            var builder = new DeckingGridBuilder(HttpContext.Session);

            builder.CurrentRoute.PageSize = pagesize;
            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }
    }
}
