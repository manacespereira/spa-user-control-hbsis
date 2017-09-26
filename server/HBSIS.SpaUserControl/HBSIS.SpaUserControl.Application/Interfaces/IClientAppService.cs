using System;
using System.Collections.Generic;
using HBSIS.SpaUserControl.Application.ViewModels;
using HBSIS.SpaUserControl.Domain.Models;

namespace HBSIS.SpaUserControl.Application.Interfaces
{
    public interface IClientAppService
    {
        void Register(ClientViewModel clientViewModel);
        IEnumerable<ClientViewModel> GetAll();
        ClientViewModel GetById(int id);
        void Update(ClientViewModel clientViewModel);
        void Remove(int id);
    }
}
