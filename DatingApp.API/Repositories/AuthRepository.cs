using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Infracstructure.Contracts;
using DatingApp.API.Models;
using DatingApp.API.Repositories.Interface;

namespace DatingApp.API.Repositories
{
    
    public class AuthRepository : IAuthRepository
    {
        private readonly IBaseRepository<DataContext,User> _usersRepository;
        private readonly IUnitOfWork _uow;
        public AuthRepository(IBaseRepository<DataContext,User> usersRepository,
        IUnitOfWork uow)
        {
            this._usersRepository = usersRepository;
            this._uow = uow;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _usersRepository.SingleOrDefault(x=>x.UserName == userName);

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
            await _usersRepository.Add(user);
            await _uow.Complete();
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
            if(await _usersRepository.Exists(x=>x.UserName == userName))
            return true;

            return false;
        }
    }
}