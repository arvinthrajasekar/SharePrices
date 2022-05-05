using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharePrices.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace SharePrices.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ISharesRepository _sharesRepository;
        //private readonly ShareDbContext _shareDbContext;
        //private readonly IMapper _mapper;

        public HomeController(ISharesRepository sharesRepository, ShareDbContext shareDbContext)
        {
            _sharesRepository = sharesRepository;
            

        }
        public ActionResult Index() 
        {
            return View();
        }
        
       [HttpGet]
        public ActionResult<Shares> GetPrice(string name)
        {
            try
            {                
                if (string.IsNullOrEmpty(name))
                {
                    ModelState.AddModelError("Name", "Name is required!!!");
                    return BadRequest("Name is required!!!");
                }
                else // (string.IsNullOrEmpty(name))
                {
                    string CompNameRegex = @"^(?=.*[a - zA - Z0 - 9]).+$";
                    Regex re = new Regex(CompNameRegex);
                    if (!re.IsMatch(name))
                    {
                        ModelState.AddModelError("Name", "Company Name is not valid.");
                        return BadRequest("Company Name is not valid.");
                    }
                }
                if (ModelState.IsValid)
                {
                    //List<Shares> AllShares = new List<Shares>();
                    // AllShares.Add(new Shares { Name = "3M India Ltd", Price = 21145 });
                    //AllShares.Add(new Shares { Name = "Aarti Drugs Ltd", Price = 519 });
                    //AllShares.Add(new Shares { Name = "Tata Power", Price = 277.8 });
                    //AllShares.Add(new Shares { Name = "HDFC Bank", Price = 1516.75 });
                    //AllShares.Add(new Shares { Name = "Zee Entertainment", Price = 284.75 });

                    /*var result = _sharesRepository.GetShares(name);
                                 

                    //result = AllShares.FirstOrDefault(m=> m.Name == name);
                    if (result == null)
                    {
                        return NotFound("Company Does not exist.");

                    }*/
                    string apiURL = "http://localhost:37211/sharesapi/home/";

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(apiURL);
                    client.DefaultRequestHeaders.Clear();

                    HttpResponseMessage response = client.GetAsync( name ).Result;
                    Shares result = new Shares();
                    if (response.IsSuccessStatusCode)
                    {
                        var ShareResponse = response.Content.ReadAsStringAsync().Result;
                        result = JsonConvert.DeserializeObject<Shares>(ShareResponse);
                        return Json(result);
                        //var result2 =  response.Content.ReadAsAsync<Shares>();
                    }
                    var OtherResponses = response.Content.ReadAsStringAsync().Result;

                    return BadRequest(OtherResponses);
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

        

        [HttpGet]
        public IActionResult GetALL()
        {

            //var result = _sharesRepository.AllShares();

            string apiURL = "http://localhost:37211/sharesapi/home/";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiURL);
            client.DefaultRequestHeaders.Clear();

            HttpResponseMessage response = client.GetAsync("").Result;
            List<Shares> result = new List<Shares>();
            if (response.IsSuccessStatusCode)
            {
                var ShareResponse = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<List<Shares>>(ShareResponse);

                //var result2 =  response.Content.ReadAsAsync<Shares>();
            }

            return Json(result);
        }


        [HttpPost]
        //[Route("NewShare")]
        public IActionResult Post(Shares shares)
        {

            //_shareDbContext.Share.Add(shares);
            //_shareDbContext.SaveChanges();
            if (string.IsNullOrEmpty(shares.Name))
            {
                return BadRequest("Name Is Required!!!");
            }

            //if (ModelState.IsValid)
            //{
            //    _sharesRepository.CreateAsync(shares);

                /*string apiURL = "http://localhost:37211/sharesapi/home/";

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(apiURL);
                client.DefaultRequestHeaders.Clear();

                var myContent = JsonConvert.SerializeObject(shares);
                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = client.PostAsync("NewShare", byteContent).Result;
                List<Shares> result = new List<Shares>();
                if (response.IsSuccessStatusCode)
                {
                    var ShareResponse = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<Shares>>(ShareResponse);

                    //var result2 =  response.Content.ReadAsAsync<Shares>();
                }*/
            //}
            _sharesRepository.CreateAsync(shares);
            return Ok();

        }

    }
}

