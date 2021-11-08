using ArcadeScore.Application.ViewModels;
using ArcadeScore.Domain.Commads.Usuario;
using ArcadeScore.Domain.Models;
using AutoMapper;

namespace ArcadeScore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {

            //Arcade
            CreateMap<UsuarioModel, UsuarioViewModel>();
            CreateMap<UsuarioCreateCommand, UsuarioViewModel>();
            CreateMap<UsuarioEditCommand, UsuarioViewModel>();


        }

    }
}
