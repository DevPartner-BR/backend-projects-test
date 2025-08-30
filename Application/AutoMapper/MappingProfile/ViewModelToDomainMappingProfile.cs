using Application.Model;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper.MappingProfile
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile() : base("ViewModelToDomainMappings")
        {
            CreateMap<NotaFiscalVW, NotaFiscal>();
        }
    }
}
