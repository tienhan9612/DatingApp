using Abp.Application.Services;
using seafood.MultiTenancy.Dto;

namespace seafood.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

