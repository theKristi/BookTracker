using System;
using System.Collections.Generic;
using System.Text;
using BookTracker.Models;
using BookTracker.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace BookTrackerTests.HelperMocks
{
   internal class Mocks
    {
        public static Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            Mock<IUserStore<ApplicationUser>> userStore = new Mock<IUserStore<ApplicationUser>>();
            Mock<Microsoft.Extensions.Options.IOptions<IdentityOptions>>
                options = new Mock<IOptions<IdentityOptions>>();
            Mock<IPasswordHasher<ApplicationUser>> passwordHasher = new Mock<IPasswordHasher<ApplicationUser>>();
            Mock<IEnumerable<IUserValidator<ApplicationUser>>> userValidators =
                new Mock<IEnumerable<IUserValidator<ApplicationUser>>>();
            Mock<IEnumerable<IPasswordValidator<ApplicationUser>>> passwordValidators =
                new Mock<IEnumerable<IPasswordValidator<ApplicationUser>>>();
            Mock<ILookupNormalizer> lookupNormalizer = new Mock<ILookupNormalizer>();
            Mock<IdentityErrorDescriber> describer = new Mock<IdentityErrorDescriber>();
            Mock<IServiceProvider> services = new Mock<IServiceProvider>();
            Mock<ILogger<UserManager<ApplicationUser>>> logger = new Mock<ILogger<UserManager<ApplicationUser>>>();
        }
    }
}
