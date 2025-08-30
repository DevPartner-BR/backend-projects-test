using Application.App;
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

            #region Application
            container.Register<INotaFiscalApp, NotaFiscalApp>();
            #endregion

            #region Domain Services
            container.Register<INotaFiscalService, NotaFiscalService>();
            #endregion

            #region infrastructure Repositories
            container.Register<INotaFiscalRepository, NotaFiscalRepository>();
            #endregion

        }
    }
}
