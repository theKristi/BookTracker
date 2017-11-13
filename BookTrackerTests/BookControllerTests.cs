using BookTracker.Services;
using Moq;

using Xunit;

namespace BookTrackerTests
{
    public class BookControllerTests
    {
        [Fact]
        public void LibraryReturnsListBookView()
        {
            var mockService = new Mock<IBookService>();
            mockService.Setup(x=>x.GetAllBooks(It.IsAny))
        }
    }
}
