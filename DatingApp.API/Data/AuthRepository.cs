using System;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dbContext;
        public AuthRepository(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x=>x.UserName == userName);

            if(user == null)
                return null;

            if(!VerifyPasswordHash(password,user.PassWordHash, user.PassWordSalt))
                return null;

            return user;
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               var computeddHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(var i=0; i< computeddHash.Length; i++)
                {
                    if(computeddHash[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PassWordHash = passwordHash;
            user.PassWordSalt = passwordSalt;
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }


        }

        public async Task<bool> UserExists(string userName)
        {
            if(await _dbContext.Users.AnyAsync(x=>x.UserName == userName))
            return true;

            return false;
        }
    }
}