using Application.AutoMapper.MappingProfile;
using AutoMapper;

namespace Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static Mapper _mapper;

        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }

        public static void Reset() {
            Mapper.Reset();
        }
    }
}
