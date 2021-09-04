using System.Threading.Tasks;
using Abp.Application.Services;
using seafood.Authorization.Accounts.Dto;

namespace seafood.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
