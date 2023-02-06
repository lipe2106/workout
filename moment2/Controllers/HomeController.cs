using Microsoft.AspNetCore.Mvc;
using moment2.Models;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace moment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/")] // Self decided route to index
        [Route("/home")] // Self decided route to index
        [Route("/index")]
        [Route("/startsida")] // Self decided route to index
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] // Handles input from index form
        [Route("/")] // Self decided route to index
        [Route("/home")] // Self decided route to index
        [Route("/index")]
        [Route("/startsida")] // Self decided route to index
        public IActionResult Index(string amount)
        {
            // Save input from set goal form in session variable
            HttpContext.Session.SetString("mySession", amount);

            // Get session variable and show below form
            ViewBag.sessionContent = "Du har satt ditt mål till " + HttpContext.Session.GetString("mySession") + " gånger. Det kommer du klara!";

            return View();
        }



        [HttpGet]
        [Route("/workout")]
        [Route("/träning")] // Self decided route to workout
        public IActionResult Workout()
        {
            return View();
        }
         
        [HttpPost] // Handles input from workout form
        [Route("/workout")]
        [Route("/träning")] // Self decided route to workout
        public IActionResult Workout(WorkoutModel model)
        { 
            if(ModelState.IsValid)
            {
                // If input in form is correct

                // Read json- file, convert to list and store according to model
                var jsonStr = System.IO.File.ReadAllText("workout.json");
                var jsonObj = JsonConvert.DeserializeObject<List<WorkoutModel>>(jsonStr);

                // Control if json read is correct
                if(jsonObj != null)
                {
                    // Add new workout to list and json- file
                    jsonObj.Add(model);
                    System.IO.File.WriteAllText("workout.json", JsonConvert.SerializeObject(jsonObj, Formatting.Indented));

                    // Redirect to result page
                    return RedirectToAction("Result", "Home");
                }
            }
            return View(); 
        }

        [HttpGet]
        [Route("/result")]
        [Route("/resultat")] // Self decided route to result
        public IActionResult Result()
        {
            // Get session variable and send to Result view
            if (HttpContext.Session.GetString("mySession") != null)
            {
                ViewBag.sessionContent = "Ditt mål är att träna " + HttpContext.Session.GetString("mySession") + " gånger.";
            }

            // Read json- file, convert to list and store according to model
            var jsonStr = System.IO.File.ReadAllText("workout.json");
            var jsonObj = JsonConvert.DeserializeObject<List<WorkoutModel>>(jsonStr);

            // Return jsonObj to Result view
            return View(jsonObj);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}