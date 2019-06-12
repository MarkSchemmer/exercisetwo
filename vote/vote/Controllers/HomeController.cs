using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vote.Models;

namespace vote.Controllers
{
    public class HomeController : Controller
    {
        public GameContext db { get; set; }

        public HomeController(GameContext context)
        {
            this.db = context;
        }
        public class FormModel
        {
            public string gender { get; set; }
        }

        [HttpPost("vote")]
        public IActionResult voteNow(FormModel value)
        {
            var v = value.gender;
            var game = this.db.game.FirstOrDefault(g => g.Id == 1);
            if (v == "male")
            {
                game.Count = game.Count + 1;
                game.Male = game.Male + 1;
            } else
            {
                game.Count = game.Count + 1;
                game.Femail = game.Femail + 1;
            }
            this.db.SaveChanges();
            return RedirectToAction("About");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            var game = this.db.game.FirstOrDefault(g => g.Id == 1);
            var male = game.Male;
            var female = game.Femail;
            var total = game.Count;
            double malePercent = ((double)male / (double)total) * 100.0;
            double femalePercent = ((double)female / (double)total) * 100.0;

            ViewData["male"] = Math.Round(malePercent);
            ViewData["female"] = Math.Round(femalePercent);

            ViewData["whoIsBigger"] = male > female ? true : false;


            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
