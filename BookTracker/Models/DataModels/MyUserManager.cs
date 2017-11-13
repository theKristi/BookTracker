using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookTracker.Models.DataModels
{
    public class MyUserManager<TUser>  :UserManager<TUser> where TUser : class
    {
        public MyUserManager(IUserStore<TUser> userStore, Microsoft.Extensions.Options.IOptions<IdentityOptions>options, IPasswordHasher<TUser> passwordHasher, IEnumerable<IUserValidator<TUser>> userValidators,IEnumerable<IPasswordValidator<TUser>> passwordValidators, ILookupNormalizer lookupNormalizer) : base(userStore,options,passwordHasher,userValidators,lookupNormalizer) { }
    }
}
