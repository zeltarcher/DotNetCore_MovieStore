using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;//hashing and salt
using System.Security.Cryptography;//hashing and salt
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserLoginResponseModel> Login(UserLoginRequestModel model)
        {
            var dbUser = await _userRepository.GetUserByEmail(model.Email);
            if(dbUser == null)
            {
                return null;
            }
            //get the hashed pass and salt from db
            var hashedPass = GetHashedPassword(model.Password, dbUser.Salt);
            if(hashedPass == dbUser.HashedPassword)
            {
                //success
                var userLoginResponseModel = new UserLoginResponseModel
                {
                    id = dbUser.Id,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    Email = dbUser.Email
                };

                return userLoginResponseModel;
            }
            return null;
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel model)
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
            var salt = GenerateSalt();
            //hash pass with salt
            var hashedPass = GetHashedPassword(model.Password,salt);
            //Create user entiry obj
            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Salt = salt,
                HashedPassword = hashedPass,
                DateOfBirth = model.DateOfBirth
            };
            //save salt and hashed pass to db
            var createdUser = await _userRepository.AddAsync(user);
            var userRegisterResponseModel = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };
            return userRegisterResponseModel;

        }

        private string GenerateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string GetHashedPassword(string pass,string salt)
        {
            //never ever create your own hashing alg
            //always use industry tried and tested hashing alg
            //Aarogon2 - another hashing alg method
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                                     password: pass,
                                                                     salt: Convert.FromBase64String(salt),
                                                                     prf: KeyDerivationPrf.HMACSHA512,
                                                                     iterationCount: 10000,
                                                                     numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
