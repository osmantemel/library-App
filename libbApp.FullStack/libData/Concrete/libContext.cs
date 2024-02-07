using libEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libData.Concrete
{
    public class libContext:DbContext
    {
        public DbSet<books> books { get; set; }
        public DbSet<loginAdmin> loginAdmin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-J1U77KI\\SQLEXPRESS;database=books;trusted_connection=true;");
        }
    }
}
