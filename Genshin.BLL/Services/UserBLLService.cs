using Genshin.BLL.Interfaces;
using Genshin.DAL.Entities;
using Genshin.DAL.Repositories;
using Crypt = BCrypt.Net;

namespace Genshin.BLL.Services
{
    public class UserBLLService : IUserBLLService
    {
        private readonly IUserRepository _repo;

        public UserBLLService(IUserRepository repo)
        {
            _repo = repo;
        }
        public UserEntity Login(string email, string motDePasse)
        {
            string pwdToCheck = _repo.CheckPassword(email);
            if (Crypt.BCrypt.Verify(motDePasse, pwdToCheck))
            {
                return _repo.Login(email);
            }
            throw new InvalidOperationException("Email ou mot de passe incorrect");
        }

        public void Register(string username, string motDePasse, string email)
        {
            //string salt = Crypt.BCrypt.GenerateSalt();
            //string hash = Crypt.BCrypt.HashPassword(password, salt);
            string hash = Crypt.BCrypt.HashPassword(motDePasse);

            _repo.Register(username, hash, email);
        }
    }
}
