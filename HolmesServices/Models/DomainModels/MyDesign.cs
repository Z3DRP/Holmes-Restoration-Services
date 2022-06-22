using HolmesServices.DataAccess;
using HolmesServices.Models.DTOs;
using HolmesServices.Models.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolmesServices.Models.DomainModels
{
    public class MyDesign
    {
        private const string DesignKey = "mydesign";
        private const string CountKey = "mycount";
        private const string DeckKey = "mydeck";
        private const string DeckCount = "deckcount";
        private const string RailKey = "myrail";
        private const string RailCount = "railcount";

        private List<DesignItem> items { get; set; }
        private List<DesignItemDTO> storedItems { get; set; }
        private ISession session { get; set; }
        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }
        public MyDesign(HttpContext ctx)
        {
            session = ctx.Session;
            requestCookies = ctx.Request.Cookies;
            responseCookies = ctx.Response.Cookies;
        }
        public void Load(Repo<Design> data)
        {
            items = session.GetObject<List<DesignItem>>(DesignKey);

            if (items == null)
            {
                items = new List<DesignItem>();
                storedItems = requestCookies.GetObject<List<DesignItemDTO>>(DesignKey);
            }

            if (storedItems?.Count > items?.Count)
            {
                foreach (DesignItemDTO storedItem in storedItems)
                {
                    var design = data.Get(new QueryOptions<Design>
                    {
                        Includes = "Type, Group",
                        Where = m => m.Id == storedItem.DesignID
                    });

                    if (design != null)
                    {
                        var dto = new DesignDTO();
                        dto.Load(design);

                        DesignItem item = new DesignItem { Design = dto, };
                        items.Add(item);
                    }
                }
                Save();
            }
        }
        // this needs to be redone: need to rethink the session design
        // need to have other info stored like customer info and dimensions
        public double Cost => items.Sum(i => i.Design.Estimate);

        public int? Count => session.GetInt32(CountKey) ?? requestCookies.GetInt32(CountKey);

        public IEnumerable<DesignItem> List => items;

        public DesignItem GetbyId(int id) =>
            items.FirstOrDefault(di => di.Design.DesignId == id);

        public void Add(DesignItem item)
        {
            var itemInDesign = GetbyId(item.Design.DesignId);

            if (itemInDesign == null)
                items.Add(item);
            else
            {
                items.Clear();
                items.Add(item);
            }
      
        }
        public void Edit(DesignItem item)

        {
            var itemInDesign = GetbyId(item.Design.DesignId);

            if (itemInDesign != null)
                item.Design.DesignId = itemInDesign.Design.DesignId;
        }
        public void Remove(DesignItem item) => items.Remove(item);
        public void Clear() => items.Clear();
        public void Save()
        {
            if (items.Count == 0)
            {
                session.Remove(DesignKey);
                session.Remove(CountKey);
                responseCookies.Delete(DesignKey);
                responseCookies.Delete(CountKey);
            }
            else
            {
                session.SetObject<List<DesignItem>>(DesignKey, items);
                session.SetInt32(CountKey, items.Count);
                responseCookies.SetObject<List<DesignItemDTO>>(DesignKey, items.ToDTO());
            }
        }
    }
}
