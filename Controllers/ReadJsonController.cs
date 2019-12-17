using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apilab.Controllers
{
    public partial class RootObject
    {
        public string Name { get; set; }
        public dynamic[] Content { get; set; }
        public long? Value { get; set; }
    }


    [ApiController]
    [Route("[controller]")]
    public class ReadJsonController : ControllerBase
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        private IActionResult View()
        {
            var path = "data.json";
            try
            {
                using StreamReader sr = new StreamReader(path);
                var jsonstring = sr.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<RootObject>(jsonstring);
                return new JsonResult(obj);
            }
            catch (IOException e)
            {
                Console.WriteLine("File cant be read " + path);
                return new NotFoundResult();
            }
        }
    }
}