using HolmesServices.Models;
using HolmesServices.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.DataAccess.Repositories
{
    public class HolmesStoreUnitOfWork : IHolmesStoreUnitOfWork
    {
        private HolmesContext hctx { get; set; }
        public HolmesStoreUnitOfWork(HolmesContext ctx) => hctx = ctx;
        private Repo<Decking> deckData;
        public Repo<Decking> Decks
        {
            get
            {
                if (deckData == null)
                    deckData = new Repo<Decking>(hctx);
                return deckData;
            }
        }
        private Repo<Railing> railData;
        public Repo<Railing> Rails
        {
            get
            {
                if (railData == null)
                    railData = new Repo<Railing>(hctx);
                return railData;
            }
        }
        private Repo<Rail_Type> railTypeData;
        public Repo<Rail_Type> RailTypes
        {
            get
            {
                if (railTypeData == null)
                    railTypeData = new Repo<Rail_Type>(hctx);
                return railTypeData;
            }
        }
        private Repo<Deck_Type> deckTypeData;
        public Repo<Deck_Type> DeckTypes
        {
            get
            {
                if (deckTypeData == null)
                    deckTypeData = new Repo<Deck_Type>(hctx);
                return deckTypeData;
            }
        }
        private Repo<Price_Groups> groupData;
        public Repo<Price_Groups> Groups
        {
            get
            {
                if (groupData == null)
                    groupData = new Repo<Price_Groups>(hctx);
                return groupData;
            }
        }
    }
}
