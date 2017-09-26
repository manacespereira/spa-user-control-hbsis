using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HBSIS.SpaUserControl.Application.Interfaces;
using HBSIS.SpaUserControl.Application.ViewModels;
using HBSIS.SpaUserControl.Domain.Interfaces;
using HBSIS.SpaUserControl.Domain.Models;

namespace HBSIS.SpaUserControl.Application.Services
{
    public class ClientAppService : IClientAppService
    {
        private readonly IClientRepository _clientRepository;

        public ClientAppService(IClientRepository clientRepository)
        {
            this._clientRepository = clientRepository;
        }

        public ClientViewModel GetByEmail(string email)
        {
            var client = Mapper.Map<ClientViewModel>(_clientRepository.GetByEmail(email));
            return client;
        }

        public void Register(ClientViewModel clientViewModel)
        {
            var client = Mapper.Map<Client>(clientViewModel);
            _clientRepository.Add(client);
        }

        public IEnumerable<ClientViewModel> GetAll()
        {
            var clients = Mapper.Map<IEnumerable<ClientViewModel>>(_clientRepository.Get().ToList());
            return clients;
        }

        public ClientViewModel GetById(int id)
        {
            var client = Mapper.Map<ClientViewModel>(_clientRepository.GetById(id));
            return client;
        }

        public void Update(ClientViewModel clientViewModel)
        {
            var oldClient = _clientRepository.GetById(clientViewModel.Id);
            var updatedClient = Mapper.Map(clientViewModel, oldClient);
            _clientRepository.Update(updatedClient);
        }

        public void Remove(int id)
        {
            var client = _clientRepository.GetById(id);
            _clientRepository.Remove(client);
        }
    }
}
