using AutoMapper;
using HBSIS.SpaUserControl.Application.ViewModels;
using HBSIS.SpaUserControl.CrossCutting.Identity.Entities;
using Client = HBSIS.SpaUserControl.Domain.Models.Client;

namespace HBSIS.SpaUserControl.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClientViewModel, Client>();
            CreateMap<UserViewModel, User>();
        }
    }
}
