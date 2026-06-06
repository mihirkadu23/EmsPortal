
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EmsPotral.Models;


namespace EmsPotral.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
            ) : base(options) { }
        public DbSet<Emp> Employee { get; set; }
    }
}
