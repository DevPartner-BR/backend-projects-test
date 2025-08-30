using Application;
using Application.Interfaces;
using Data.Repositories;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Services;
using SimpleInjector;

namespace Devpartner.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<INotaFiscalAppService, NotaFiscalAppService>();
            container.Register<INotaFiscalService, NotaFiscalService>();
            container.Register<INotaFiscalRepository, NotaFiscalRepository>();
        }
    }
}