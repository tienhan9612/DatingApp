using System.Threading.Tasks;
using Abp.Application.Services;
using seafood.Sessions.Dto;

namespace seafood.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
