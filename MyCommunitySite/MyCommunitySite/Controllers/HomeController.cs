using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCommunitySite.Models;
using MyCommunitySite.Models.Quizz;

namespace MyCommunitySite.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<AppUser> userManager;

        public HomeController(UserManager<AppUser> uManager)
        {
            this.userManager = uManager;
        }

        public IActionResult Index()
        {
            var appUsers = userManager.Users.ToList();
            return View(appUsers);
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
        
    }
}
