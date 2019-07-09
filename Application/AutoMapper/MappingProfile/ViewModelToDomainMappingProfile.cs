using Application.Model;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper.MappingProfile
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<NotaFiscal, NotaFiscalViewModel>();
        }
    }
}