using BLL.IServices;
using BLL.Models;
using DAL.IRepositories;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<Member> Authenticate(string email, string password)
        {
            var member = await _accountRepository.GetMember(email);
            if (member == null)
            {
                return null;
            }
            bool isValid = BCrypt.Net.BCrypt.Verify(password, member.Password);
            return isValid ? member : null;
        }

        public async Task<Member> SignUp(CreateAccount createAccount)
        {
            var member = new Member
            {
                Email = createAccount.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(createAccount.Password),
                CompanyName = createAccount.CompanyName,
                City = createAccount.City,
                Country = createAccount.Country,
                RoleId = createAccount.RoleId,
                Status = createAccount.Status,
            };
            var account = await _accountRepository.CreateMember(member);
            return account;
        }
    }
}
