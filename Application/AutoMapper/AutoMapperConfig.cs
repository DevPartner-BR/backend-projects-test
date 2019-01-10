using Application.Model;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {

                // Entitidade para View Model
                x.CreateMap<NotaFiscal, NotaFiscalViewModel>();

                // View Model para Entidade
                x.CreateMap<NotaFiscalViewModel, NotaFiscal>()
                    .ForSourceMember(p => p.Id, a => a.Ignore());

            });
        }
    }
}
