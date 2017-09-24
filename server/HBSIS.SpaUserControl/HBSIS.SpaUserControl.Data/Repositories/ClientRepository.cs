using System.Linq;
using HBSIS.SpaUserControl.Domain.Interfaces;
using HBSIS.SpaUserControl.Domain.Models;

namespace HBSIS.SpaUserControl.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public Client GetByEmail(string email)
        {
            return Ctx.Clients.FirstOrDefault(x => x.Email == email);
        }
    }
}
