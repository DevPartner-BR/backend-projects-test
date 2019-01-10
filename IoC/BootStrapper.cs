using Data.Context;
using Data.Repositories;
using Domain.Interfaces.Repository;
using SimpleInjector;

namespace Devpartner.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(Container container)
        {

            // container.Options.LifestyleSelectionBehavior = new SingletonLifestyleSelectionBehavior();
            container.Options.DefaultLifestyle = Lifestyle.Scoped;

            // Data
            container.Register<SystemContext>();

            // Repositorios
            container.Register<INotaFiscalRepository, NotaFiscalRepository>();

            // Domain

            // Aplication

        }
    }
}
