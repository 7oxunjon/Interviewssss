using DATA.Model;
using Helper.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Interviewssss.Context
{
    public class AppDbContext : IdentityDbContext<ApiUser,Role,long>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext)
             : base(dbContext) { }
        public DbSet<SuhbatOluvchi> suhbatOluvchis { get; set; }
        public DbSet<SuhbatTopshiruvchi> topshiruvchi { get; set; }
        public DbSet<ApiUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)    
        {
            builder.Entity<SuhbatOluvchi>().
                HasMany(p => p.suhbatTopshiruvchis).
                WithOne(p => p.suhbatOluvchi).
                HasForeignKey(p => p.OluvchiId);
            // bular Helper class libarydan kelyapti
            builder.ApplyConfiguration(new RoleConfiguration()); 
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            base.OnModelCreating( builder);
        }
    }
}
