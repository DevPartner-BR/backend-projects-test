using Application.Model;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper.MappingProfile
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() : base("DomainToViewModelMappings")
        {
            CreateMap<NotaFiscal, NotaFiscalVW>();
        }

    }
}
