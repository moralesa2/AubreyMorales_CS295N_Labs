using Microsoft.AspNetCore.Mvc;
using MyCommunitySite.Models;
using MyCommunitySite.Controllers;
using CommunitySiteTest.FakeRepo;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.Pkcs;

namespace CommunitySiteTest
{
    public class CommunitySiteTests 
    {
        FakeMessageRepository mRepo = new FakeMessageRepository();
        MessagesController controller;

        public CommunitySiteTests()
        {
            controller = new MessagesController(mRepo, null);
        }

        [Fact]
        public void Message_PostTest_Success()
        {
            var result = controller.Message(new Message());

            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void Message_PostTest_Failure()
        {
            // error must be forced for testing
            controller.ModelState.AddModelError("Error", "validation error");

            var result = controller.Message(new Message());

            Assert.IsType<ViewResult>(result);
        }
    }

}