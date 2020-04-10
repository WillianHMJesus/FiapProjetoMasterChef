using AutoMapper;
using Domain.Entities;
using MasterChef.Models;

namespace MasterChef.Mappers
{
    public class ViewModelToDamainMappingProfille : Profile
    {
        public ViewModelToDamainMappingProfille()
        {
            CreateMap<ReceitaModel, Receita>().ReverseMap();
            CreateMap<CategoriaModel, Categoria>().ReverseMap();
            CreateMap<UsuarioModel, Usuario>().ReverseMap();
            CreateMap<CategoriaModel, Comentario>().ReverseMap();
        }
    }
}