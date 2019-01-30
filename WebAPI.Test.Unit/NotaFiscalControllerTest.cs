using Devpartner.Infra.CrossCutting.IoC;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.Controllers;

namespace WebAPI.Test.Unit
{
    [TestClass]
    public class NotaFiscalControllerTest
    {
        [TestClass]
        public class TestSimpleProductController
        {
            INotaFiscalRepository repository;
            NotaFiscalService service;
            IList<NotaFiscal> notasFiscais;

            public TestSimpleProductController()
            {
                var container = new Container();
                container = BootStrapper.RegisterServices(container);
                container.Verify();

                repository = container.GetInstance<INotaFiscalRepository>();
                service = container.GetInstance<NotaFiscalService>();
                notasFiscais = CarregarNotas();
            }


            [TestMethod]
            public void GetAllNotasFiscais()
            {

                var controller = NotaFiscalController();

                var resultController = controller.Get() as ResponseMessageResult;

                Task<string> content = resultController.Response.Content.ReadAsStringAsync();

                IList<NotaFiscal> objNotasFiscais = JsonConvert.DeserializeObject<IList<NotaFiscal>>(content.Result);

                Assert.AreEqual(notasFiscais.Count, objNotasFiscais.Count);
            }

            [TestMethod]
            public void GetNotaFiscal_Id()
            {

                var controller = NotaFiscalController();

                var resultController = controller.Get(notasFiscais[1].notaFiscalId) as ResponseMessageResult;

                Task<string> content = resultController.Response.Content.ReadAsStringAsync();

                NotaFiscal objNotasFiscais = JsonConvert.DeserializeObject<NotaFiscal>(content.Result);

                Assert.AreEqual(notasFiscais[1].numeroNf, objNotasFiscais.numeroNf);
            }

            [TestMethod]
            public void GetNotaFiscal_Id_NotaFiscal_Inexistente()
            {

                var controller = NotaFiscalController();

                var resultController = controller.Get(999) as ResponseMessageResult;           

                Assert.AreEqual(resultController.Response.StatusCode, HttpStatusCode.NotFound);
            }

            private IList<NotaFiscal> CarregarNotas()
            {

                var Notas = service.ExibirNotas();

                return Notas;
            }

            private NotaFiscalController NotaFiscalController()
            {
                NotaFiscalController controller = new NotaFiscalController(repository, service);

                controller.Request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:61171/NotaFiscal/")
                };

                controller.Configuration = new HttpConfiguration();

                controller.Configuration.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional });

                return controller;
            }
        }
    }
}
