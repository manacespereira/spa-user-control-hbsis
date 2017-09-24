
using HBSIS.SpaUserControl.Domain.Core;
using HBSIS.SpaUserControl.Domain.Models;

namespace HBSIS.SpaUserControl.Domain.Interfaces
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        Client GetByEmail(string email);
    }
}
