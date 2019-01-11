using Application.App;
using Application.Interfaces;
using Data.Context;
using Data.Context.UnitOfWork;
using Data.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Services;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using SimpleInjector.Lifestyles;

namespace Devpartner.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(Container container)
        {

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Data
            container.Register<SystemContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            // Repositorios
            container.Register<INotaFiscalRepository, NotaFiscalRepository>(Lifestyle.Scoped);

            // Domain.Service
            container.Register<INotaFiscalService, NotaFiscalService>(Lifestyle.Scoped);

            // Aplication
            container.Register<INotaFiscalApplication, NotaFiscalApplication>(Lifestyle.Scoped);

        }
    }
}
