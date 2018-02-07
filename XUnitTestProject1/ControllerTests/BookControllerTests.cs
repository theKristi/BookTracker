using System.Collections.Generic;
using BookTracker.Controllers;
using BookTracker.Models;
using BookTracker.Models.ServiceModels;
using BookTracker.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BookTrackerTests.ControllerTests
{
    public class BookControllerTests
    {
        [Fact]
        public void LibraryReturnsListBookView()
        {
            var mockService = new Mock<IBookService>();
            var mockUser =  ;
            var serviceModels = new List<BookServiceModel>();
            mockService.Setup(x => x.GetAllBooks(It.IsAny<UserManager<ApplicationUser>>())).Returns(serviceModels);
            var controller=new BookController(mockService.Object,mockUser.Object);
            IActionResult result = controller.Library();
            result.GetType().Should().BeOfType<PartialViewResult>();
            var view = result as PartialViewResult;
            view.ViewName.ShouldBeEquivalentTo("ListBooks");


        }
    }
}
