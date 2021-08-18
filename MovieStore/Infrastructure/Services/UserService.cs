using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginRequestModel> Login(LoginRequestModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterResponseModel model)
        {
            //make sure the user entered email does not exist in database
            var dbUser = await _userRepository.GetUserByEmail(model.Email);
            if (dbUser != null)
            {
                //email registered
                throw new ConflictException("Email already exists!");
            }

            //user does not exist
            //generate unique salt

            //hash pass with salt

            //save salt and hashed pass to db

        }

        private string GenerateSalt()
        {
            return string.Empty;
        }

        private string GetHashedPassword(string pass,string salt)
        {
            //never ever create your own hashing alg
            //always use industry tried and tested hashing alg


            return string.Empty;
        }
    }
}
