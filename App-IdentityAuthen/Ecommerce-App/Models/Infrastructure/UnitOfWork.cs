using System.Threading.Tasks;
using Ecommerce_App.Models.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_App.Models.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;

        public UnitOfWork(DataContext dbContext)
        {
            _dbContext =  dbContext;
        }

        public async Task Complete()
        {
            await _dbContext.SaveChangesAsync();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}