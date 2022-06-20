using HolmesServices.Models;
using HolmesServices.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.DataAccess.Repositories
{
    interface IHolmesStoreUnitOfWork
    {
        Repo<Decking> Decks { get; set; }
        Repo<Railing> Rails { get; set; }
        Repo<Rail_Type> RailTypes { get; set; }
        Repo<Deck_Type> DeckTypes { get; set; }
        Repo<Price_Groups> Groups { get; set; }
    }
}
