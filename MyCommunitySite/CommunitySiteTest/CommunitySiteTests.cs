using Microsoft.AspNetCore.Mvc;
using MyCommunitySite.Models;
using MyCommunitySite.Controllers;
using CommunitySiteTest.FakeRepo;
using Microsoft.AspNetCore.Identity;

namespace CommunitySiteTest
{
    public class CommunitySiteTests 
    {
        IRepository<Message> mRepo = new FakeMessageRepository();
        MessagesController controller;

        public CommunitySiteTests()
        {
            controller = new MessagesController(mRepo, null);
        }

        [Fact]
        public void Message_PostTest_Success()
        {
            var result = controller.Edit(new Message());

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Message_PostTest_Failure()
        {
            // error must be forced for testing
            controller.ModelState.AddModelError("Error", "validation error");

            var result = controller.Edit(new Message());

            Assert.IsType<ViewResult>(result);
        }
    }

}