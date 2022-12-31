using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPIRestfulIdentity.DataAccess.Model;

namespace WebAPIRestfulIdentity.DataAccess
{
    public class IdentityContext: IdentityDbContext<User, Role, int,
                                                        UserClaim, UserRole, UserLogin,
                                                        RoleClaim, UserToken>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.HasDefaultSchema("dbo");

            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<UserClaim>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<UserLogin>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<RoleClaim>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            builder.Entity<UserToken>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
            });

            builder.Entity<UserRole>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                entity.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                entity.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

                entity.ToTable("UserRoles");
            });
        }
    }
}
