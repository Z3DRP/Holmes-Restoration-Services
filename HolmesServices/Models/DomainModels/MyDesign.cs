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
        public void Load(Repo<Material> data)
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
                    var material = data.Get(new QueryOptions<Material>
                    {
                        Includes = "Type, Group",
                        Where = m => m.Id == storedItem.MaterialId
                    });

                    if (material != null)
                    {
                        var dto = new MaterialDTO();
                        dto.Load(material);

                        DesignItem item = new DesignItem { Material = dto, };
                        items.Add(item);
                    }
                }
                Save();
            }
        }
        // this needs to be redone: need to rethink the session design
        // need to have other info stored like customer info and dimensions
        public double Cost => items.Sum(i => i.Material.Price);

        public int? Count => session.GetInt32(CountKey) ?? requestCookies.GetInt32(CountKey);

        public IEnumerable<DesignItem> List => items;

        public DesignItem GetbyId(int id) =>
            items.FirstOrDefault(di => di.Material.Id == id);

        public void Add(DesignItem item)
        {
            var itemInDesign = GetbyId(item.Material.Id);

            if (itemInDesign == null)
                items.Add(item);
            else
                // 
        }
        public void Edit(DesignItem item)
        {
            var itemInDesign = GetbyId(item.Material.Id);

            if (itemInDesign != null)
                item.Material.Id = itemInDesign.Material.Id;
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
                responseCookies.SetObject<List<DesignItemDTO>>(DesignKey, items.TODTO());
            }
        }
    }
}
