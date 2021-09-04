using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace seafood.EntityFrameworkCore
{
    public static class seafoodDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<seafoodDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<seafoodDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
