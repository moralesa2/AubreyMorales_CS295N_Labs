using Microsoft.AspNetCore.Mvc;
using MyCommunitySite.Models;
using MyCommunitySite.Models.Quizz;

namespace MyCommunitySite.Controllers
{
    public class HomeController : Controller
    {
        readonly IRepository<AppUser> userRepo;

        private readonly QueryOptions<AppUser> uOptions = new QueryOptions<AppUser>();

        public HomeController(IRepository<AppUser> uRepo)
        {
            this.userRepo = uRepo;
        }

        public IActionResult Index()
        {
            uOptions.OrderBy = appUser => appUser.UserName;
            var users = userRepo.List(uOptions);
            return View(users);
        }

        #region AppUser methods
        [HttpGet]
        public IActionResult Add()
        {
            uOptions.OrderBy = appUser => appUser.UserName;
            var appUsers = userRepo.List(uOptions);

            ViewBag.Action = "Add";
            return View("Edit", new AppUser());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var user = userRepo.Get(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(AppUser user)
        {
            if (ModelState.IsValid)
            {
                if (Int32.Parse(user.Id) == 0)
                    userRepo.Insert(user);
                else
                    userRepo.Update(user);
                userRepo.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (Int32.Parse(user.Id) == 0 ? "Add" : "Edit");
                return View(user);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = userRepo.Get(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(AppUser user)
        {
            userRepo.Delete(user);
            userRepo.Save();
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
