using Genshin.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genshin.BLL.Interfaces
{
    public interface IUserBLLService
    {
        void Register(string username, string motDePasse, string email);
        UserEntity Login(string email, string motDePasse);
    }
}
