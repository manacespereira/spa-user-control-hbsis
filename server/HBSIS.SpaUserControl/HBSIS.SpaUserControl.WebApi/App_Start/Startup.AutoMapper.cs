
using HBSIS.SpaUserControl.Application.AutoMapper;

namespace HBSIS.SpaUserControl.WebApi
{
    public partial class StartUp
    {
        public void ConfigureAutoMapper()
        {
            AutoMapperConfig.RegisterMappings();
        }
    }
}