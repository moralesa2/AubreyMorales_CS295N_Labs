using Microsoft.AspNetCore.Mvc;
using MyCommunitySite.Models;
using MyCommunitySite.Controllers;
using CommunitySiteTest.FakeRepo;

namespace CommunitySiteTest
{
    public class CommunitySiteTests 
    {
        IRepository<Message> _mRepo = new FakeMessageRepository();
        IRepository<AppUser> _uRepo = new FakeAppUserRepository();

        MessagesController _mController;
        HomeController _hController;

        Message _message = new Message();
        AppUser _user = new AppUser();

        public CommunitySiteTests()
        {
            _mController = new MessagesController(_mRepo, _uRepo);
            _hController = new HomeController(_uRepo);
        }

        [Fact]
        public void Message_PostTest_Success()
        {
            _message.Sender = new AppUser();
            _message.Recipient = new AppUser();

            var result = _mController.Edit(new Message());

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Message_PostTest_Failure()
        {
            // error must be forced for testing
            _mController.ModelState.AddModelError("Error", "validation error");
            _message.Sender = new AppUser();
            _message.Recipient = new AppUser();

            var result = _mController.Edit(_message);

            Assert.IsType<ViewResult>(result);
        }
    }

}