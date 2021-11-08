using ArcadeScore.Application.ViewModels;
using ArcadeScore.Domain.Commads.Usuario;
using ArcadeScore.Domain.Models;
using AutoMapper;

namespace ArcadeScore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //ArcadeScore
            CreateMap<UsuarioModel, UsuarioViewModel>();
            CreateMap<UsuarioViewModel, UsuarioCreateCommand>();
            CreateMap<UsuarioViewModel, UsuarioEditCommand>();


        }
    }
}
