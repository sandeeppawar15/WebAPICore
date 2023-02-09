using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPICore.Entity;

namespace WebAPICore.Repository
{
    public class WebAPICoreDbContext : DbContext
    {
        public WebAPICoreDbContext(DbContextOptions<WebAPICoreDbContext> options) :
            base(options)
        { }

        public DbSet<User>? User { get; set; }
    }
}
