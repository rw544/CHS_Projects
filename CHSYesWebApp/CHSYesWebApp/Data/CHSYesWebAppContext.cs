using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

//namespace CHSYesWebApp.Models
namespace CHSYesWebApp.Data
{
    public class CHSYesWebAppContext : DbContext
    {
        public CHSYesWebAppContext (DbContextOptions<CHSYesWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<CHSYesWebApp.Models.ServiceForm> ServiceForm { get; set; }
    }
}
