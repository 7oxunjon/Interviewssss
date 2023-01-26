using DATA.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Helper.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApiUser>
    {

        public void Configure(EntityTypeBuilder<ApiUser> builder)
        {
            var hasher = new PasswordHasher<ApiUser>();
            builder.HasData(
                new ApiUser
                {
                    Id = 1,
                    FirstName = "Oxunjon",
                    LastName = "Yoldashe",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null, "admin1234")
                },
                new ApiUser
                {
                    Id = 2,
                    FirstName = "Oxunjon",
                    LastName = "Yoldashe",
                    UserName = "admin1",
                    NormalizedUserName = "ADMIN1",
                    PasswordHash = hasher.HashPassword(null, "admin12345")
                }
            );
        }
    }
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<long>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserRole<long>> builder)
        {
            var hasher = new PasswordHasher<ApiUser>();
            builder.HasData(
                new IdentityUserRole<long>
                {
                    RoleId = 1,
                    UserId = 1
                },
                new IdentityUserRole<long>
                {
                    RoleId = 2,
                    UserId = 2
                }
            );
        }
    }
}
