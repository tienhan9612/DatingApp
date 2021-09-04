using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using seafood.Authorization.Roles;
using seafood.Authorization.Users;
using seafood.MultiTenancy;

namespace seafood.EntityFrameworkCore
{
    public class seafoodDbContext : AbpZeroDbContext<Tenant, Role, User, seafoodDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public seafoodDbContext(DbContextOptions<seafoodDbContext> options)
            : base(options)
        {
        }
    }
}
