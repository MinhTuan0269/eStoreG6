using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IAccountService
    {
        Task<Member> Authenticate(string username, string password);
        Task<Member> SignUp(CreateAccount createAccount);
    }
}
