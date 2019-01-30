using Data.Context;
using Data.Context.UnitOfWork;
using Data.Repositories;
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Devpartner.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static Container RegisterServices(Container _container)
        {

            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            _container.Register<SystemContext>(Lifestyle.Singleton);
            _container.Register<INotaFiscalRepository, NotaFiscalRepository>(Lifestyle.Singleton);
            _container.Register<NotaFiscalService>(Lifestyle.Singleton);
            //_container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Singleton);

            return _container;
        }
    }
}
