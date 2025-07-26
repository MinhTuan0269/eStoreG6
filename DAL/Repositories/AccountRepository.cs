using DAL.DBContexts;
using DAL.IRepositories;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly eStoreDbContext _context;
        public AccountRepository(eStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Member> CreateMember(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<Member?> GetMember(string email)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.Email == email && m.Status == true);
        }
    }
}
