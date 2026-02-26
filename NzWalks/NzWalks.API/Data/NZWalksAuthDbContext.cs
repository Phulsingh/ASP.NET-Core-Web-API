
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NzWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext 

    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "0f1b6829-bcc4-4d81-90ee-3283d769aa1b";
            var writerRoleId = "b8be6f6f-bb9c-4fca-bea5-5003c77e9f44";

            var Role = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "READER".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId, 
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "WRITER".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(Role);
        }
    }
}
