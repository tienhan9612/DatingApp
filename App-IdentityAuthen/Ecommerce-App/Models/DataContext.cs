using Ecommerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_App{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<User> User{get;set;}

    }
}