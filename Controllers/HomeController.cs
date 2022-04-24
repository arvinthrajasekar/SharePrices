using Microsoft.AspNetCore.Mvc;
using SharePrices.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SharePrices.Controllers
{
   
    public class HomeController : Controller
    {
        
        public ActionResult Index() 
        {
            return View();
        }
        
       [HttpPost]
        public IActionResult GetPrice(string name)
        {
            try
            {                
                if (!string.IsNullOrEmpty(name))
                {
                    string CompNameRegex = @"^(?=.*[a - zA - Z0 - 9]).+$";
                    Regex re = new Regex(CompNameRegex);
                    if (!re.IsMatch(name))
                    {
                        ModelState.AddModelError("Name", "Company Name is not valid.");
                        return BadRequest("Company Name is not valid.");
                    }

                }
                else // (string.IsNullOrEmpty(name))
                {
                    ModelState.AddModelError("Name", "Name is required!!!");
                    return BadRequest("Name is required!!!");

                }
                if (ModelState.IsValid)
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
                    //result = AllShares.FirstOrDefault(m=> m.Name == name);
                    if (result.Count() == 0)
                    {
                        return NotFound("Company Does not exist.");

                    }
                    return Json(result);
                }
                else
                {

                    return BadRequest();
                }
            }
            catch (Exception )
            {
                return BadRequest();
            }
        }

        /*public ActionResult GetPriceTest(string name)
        {
            try
            {



                if (!string.IsNullOrEmpty(name))
                {
                    string CompNameRegex = @"^(?=.*[a - zA - Z0 - 9]).+$";
                    Regex re = new Regex(CompNameRegex);
                    if (!re.IsMatch(name))
                    {
                        ModelState.AddModelError("Name", "Company Name is not valid.");
                        return BadRequest("Company Name is not valid.");
                    }

                }
                else // (string.IsNullOrEmpty(name))
                {
                    ModelState.AddModelError("Name", "Name is required!!!");
                    return BadRequest("Name is required!!!");

                }
                if (ModelState.IsValid)
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
                    //result = AllShares.FirstOrDefault(m=> m.Name == name);
                    if (result.Count() == 0)
                    {
                        return NotFound("Company Does not exist.");

                    }
                    string s = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                    //string s = result.ToString();
                    return Content(s);
                }
                else
                {

                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }*/


        [HttpPost]
        public IActionResult GetALL()
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

