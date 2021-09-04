using System.Threading.Tasks;
using seafood.Configuration.Dto;

namespace seafood.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
