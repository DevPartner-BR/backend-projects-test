using Data.Dapper;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            container.RegisterType<INotaFiscalRepository, NotaFiscalRepository>();
        }
    }
}