using Microsoft.AspNetCore.Mvc;
using SharePrices.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharePrices.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public JsonResult AJAXMethod(string name)
        {
            List<Shares> AllShares = new List<Shares>();
            AllShares.Add(new Shares { Name = "3M India Ltd", Price = 21145 });
            AllShares.Add(new Shares { Name = "Aarti Drugs Ltd", Price = 519 });
            AllShares.Add(new Shares { Name = "Tata Power", Price = 277.8 });
            AllShares.Add(new Shares { Name = "HDFC Bank", Price = 1516.75 });
            AllShares.Add(new Shares { Name = "Zee Entertainment", Price = 284.75 });
            var result = from r in AllShares
                         where r.Name == name
                         select new { Name = r.Name, Price = r.Price };
            
            return Json(result);
        }
        /*[HttpPost]
        public JsonResult AJAXMethod(string name)
        {
            Shares stock = new Shares
            {
                Name = name,
                Price = 2222
            };
            return Json(stock);
        }*/
    }
}

