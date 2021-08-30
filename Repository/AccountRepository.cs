using Microsoft.AspNetCore.Identity;
using OneToOneRelation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneToOneRelation.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new IdentityUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email
            };
           var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        //Task IAccountRepository.CreateUserAsync(SignUpUserModel userModel)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            return  await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, true);
        }

        //Task IAccountRepository.CreateUserAsync(SignUpUserModel userModel)
        //{
        //    throw new NotImplementedException();
        //}

       

    }
}
