using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.Services
{
    public class RoleService : RoleManager<IdentityRole>
    {
        public RoleService(IRoleStore<IdentityRole, string> roleStore)
            :base(roleStore)
        {

        }
    }
}
