using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

namespace BookTracker.Models.DataModels
{
    public class MyUserManager<TUser>  :UserManager<TUser> where TUser : class
    {
        public MyUserManager(IUserStore<TUser> userStore, Microsoft.Extensions.Options.IOptions<IdentityOptions>options, IPasswordHasher<TUser> passwordHasher, IEnumerable<IUserValidator<TUser>> userValidators,IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer lookupNormalizer,IdentityErrorDescriber describer, IServiceProvider services, ILogger<UserManager<TUser>> logger) : base(userStore,options,passwordHasher,userValidators,passwordValidators,lookupNormalizer,describer,services,logger) { }
    }
}
