using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using ImageSearcher.Models;
using Microsoft.CSharp.RuntimeBinder;


namespace ImageSearcher.Controllers
{
    //API: AIzaSyADTHzE85eCriGDMLjXx0WSEc2wowwJefA
    //CX: 017785651468861548536:noz7t3te8rw

    public class PageController : Controller
    {

        public ActionResult _Layout()
        {

            return View();
        }

        // GET: Page
        public ActionResult Index()
        {
            ViewBag.Message = "ImageSearcher";
            
            return View();
        }

        public ActionResult ShowSearchResults()
        {
            string searchQuery = Request["search"];
            string apiKey = "AIzaSyADTHzE85eCriGDMLjXx0WSEc2wowwJefA";
            string cx = "017785651468861548536:noz7t3te8rw";
            var results = new List<ResultItem>();


            //create a webrequest object with the specified url, its an abstract class for accessing data from the Internet. 
            var request = WebRequest.Create("https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + searchQuery);

            //provides response from a URI. (A webresponse cant create a response by itself, it has to call request.getresponse from http webrequest.)
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream datastream = response.GetResponseStream();
            StreamReader reader = new StreamReader(datastream);

            //string containing all the character from current position to the end.
            string responseString = reader.ReadToEnd();

            //dynamic is a datatype that in most cases works as an object, it changes its type based on what value is present on the right side.
            //serialize in json = to convert object to string, while deserialize string to object.


            dynamic jsonData = JsonConvert.DeserializeObject(responseString);
            foreach (var item in jsonData.items)
            {
                try { 
                    results.Add(new ResultItem
                    {
                    Title = item.title,
                    Link = item.link,
                    Snippet = item.snippet,
                    Image = item.pagemap.cse_image[0].src
                    });
                }
                catch (RuntimeBinderException e)
                {
                    
                }

            }
            return View(results.ToList());

        }
        
    }
}