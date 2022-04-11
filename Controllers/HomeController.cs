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
        public ActionResult AJAXMethod(string name)
        {
            List<Shares> AllShares = new List<Shares>();
            AllShares.Add(new Shares { Name = "3M India Ltd", Price = 21145 });
            AllShares.Add(new Shares { Name = "Aarti Drugs Ltd", Price = 519 });
            AllShares.Add(new Shares { Name = "Tata Power", Price = 277.8 });
            AllShares.Add(new Shares { Name = "HDFC Bank", Price = 1516.75 });
            AllShares.Add(new Shares { Name = "Zee Entertainment", Price = 284.75 });
            try
            {
                var result = from r in AllShares
                             where r.Name == name
                             select new { Name = r.Name, Price = r.Price };
                if(result .Count() == 0)
                {
                    return NotFound();

                }
                return Json(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        public ActionResult GetALL()
        {
            List<Shares> AllShares = new List<Shares>();
            AllShares.Add(new Shares { Name = "3M India Ltd", Price = 21145 });
            AllShares.Add(new Shares { Name = "Aarti Drugs Ltd", Price = 519 });
            AllShares.Add(new Shares { Name = "Tata Power", Price = 277.8 });
            AllShares.Add(new Shares { Name = "HDFC Bank", Price = 1516.75 });
            AllShares.Add(new Shares { Name = "Zee Entertainment", Price = 284.75 });
            return Json(AllShares);
        }
       
        
    }
}

