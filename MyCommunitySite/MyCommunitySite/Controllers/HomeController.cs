using Microsoft.AspNetCore.Mvc;
using MyCommunitySite.Models;
using MyCommunitySite.Models.Quizz;

namespace MyCommunitySite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ApplicationDbContext context { get; set; }

        public HomeController(ApplicationDbContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var users = context.AppUsers
                .OrderBy(au => au.Name)
                .ToList();
            return View(users);
        }

        #region AppUser methods
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            var user = new AppUser();

            return View("Edit", user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var user = context.AppUsers.Find(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(AppUser user)
        {
            if (ModelState.IsValid)
            {
                if (user.AppUserId == 0)
                    context.AppUsers.Add(user);
                else
                    context.AppUsers.Update(user);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (user.AppUserId == 0 ? "Add" : "Edit");
                return View(user);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = context.AppUsers.Find(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(AppUser user)
        {
            context.AppUsers.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        #endregion

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
