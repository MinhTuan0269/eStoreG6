using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContexts
{
    public class eStoreDbContextFactory : IDesignTimeDbContextFactory<eStoreDbContext>
    {
        public eStoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<eStoreDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=eStoreDB;Persist Security Info=True;User ID=sa;Password=12345;TrustServerCertificate=True;");

            return new eStoreDbContext(optionsBuilder.Options);

            
        }
    }
}
