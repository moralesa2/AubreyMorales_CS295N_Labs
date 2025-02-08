using Microsoft.AspNetCore.Mvc;
using MyCommunitySite.Models;
using MyCommunitySite.Controllers;
using CommunitySiteTest.FakeRepo;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.Pkcs;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CommunitySiteTest
{
    public class CommunitySiteTests 
    {
        FakeMessageRepository mRepo = new FakeMessageRepository();
        MessagesController controller;

        public CommunitySiteTests() 
        { 
            // arrange
            controller = new MessagesController(mRepo, null); 
        }

        [Fact]
        public async Task Message_PostTest_Success()
        {
            // act
            var result = await controller.Message(new Message());
            // assert
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task Message_PostTest_Failure()
        {
            // act
            var result = await controller.Message(new Message());
            // assert
            Assert.IsType<RedirectToActionResult>(result);
        }
    }

}