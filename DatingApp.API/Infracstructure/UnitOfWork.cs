
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Infracstructure.Contracts;
using DatingApp.API.Data;

namespace DatingApp.API.Infracstructure
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