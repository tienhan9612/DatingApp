using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_App.Models.Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        DbContext Db { get; }

        Task Complete();
    }
}