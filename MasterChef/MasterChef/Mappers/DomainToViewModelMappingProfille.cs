using AutoMapper;
using Domain.Entities;
using MasterChef.Models;

namespace MasterChef.Mappers
{
    public class DomainToViewModelMappingProfille : Profile
    {
        public DomainToViewModelMappingProfille()
        {
            CreateMap<Receita, ReceitaModel>().ReverseMap();
            CreateMap<Categoria, CategoriaModel>().ReverseMap();
            CreateMap<Usuario, UsuarioModel>().ReverseMap();
            CreateMap<Comentario, ComentarioModel>().ReverseMap();
        }
    }
}