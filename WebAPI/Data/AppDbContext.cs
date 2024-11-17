using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions dbContextOptions)
       : base(dbContextOptions)
       {
        
       }

       public DbSet<UserModel> User { get; set; }
        
    }
}

