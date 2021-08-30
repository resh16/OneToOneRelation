using Microsoft.AspNetCore.Identity;
using OneToOneRelation.Models;
using System.Threading.Tasks;

namespace OneToOneRelation.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);

        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);

        //Task CreateUserAsync(SignUpUserModel userModel);
    }
}