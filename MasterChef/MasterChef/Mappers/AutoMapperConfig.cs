using AutoMapper;

namespace MasterChef.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegistraMappeamento()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfille>();
                x.AddProfile<ViewModelToDamainMappingProfille>();
            });
        }
    }
}
