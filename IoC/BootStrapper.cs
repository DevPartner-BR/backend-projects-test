using SimpleInjector;
using Application;
using Application.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Services;
using Data.Repositories;

namespace Devpartner.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            container.Register<INotaFiscalRepository, NotaFiscalRepository>();

            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>));
            container.Register<INotaFiscalService, NotaFiscalService>();

            container.Register(typeof(IAppServiceBase<>), typeof(AppServiceBase<>));
            container.Register<INotaFiscalAppService, NotaFiscalAppService>();
        }
    }
}
