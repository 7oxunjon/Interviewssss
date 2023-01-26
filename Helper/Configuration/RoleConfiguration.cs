using DATA.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Helper.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new Role
                {
                    Id = 2,
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                }
            );
        }
    }
}
