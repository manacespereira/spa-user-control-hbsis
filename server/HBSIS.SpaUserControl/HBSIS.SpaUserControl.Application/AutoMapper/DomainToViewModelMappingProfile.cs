using AutoMapper;
using HBSIS.SpaUserControl.Application.ViewModels;
using HBSIS.SpaUserControl.CrossCutting.Identity.Entities;
using Client = HBSIS.SpaUserControl.Domain.Models.Client;

namespace HBSIS.SpaUserControl.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<User, UserViewModel>();
        }
    }
}
