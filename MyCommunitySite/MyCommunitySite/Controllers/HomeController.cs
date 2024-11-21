using Microsoft.AspNetCore.Mvc;
using MyCommunitySite.Models;
using System.Diagnostics;

namespace MyCommunitySite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Quiz()
        {
            Quiz model = new Quiz();
            return View(model);
        }
        [HttpPost]
        public IActionResult Quiz(string[] answers)
        {
            Quiz model = new Quiz();
            for (int i = 0; i < answers.Length; i++)
            {
                string answer = answers[i];
                if (answer != null)
                {
                    Question question = model.Questions[i];
                    question.UserA = answer;
                    question.isCorrect = model.CheckAnswer(question);
                }
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
