using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

using Application.Interfaces;
using Application.Model;
using WebAPI.Areas.NotaFiscal.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Net;

namespace UnitTest.Api
{
    [TestClass]
    public class ApiTeste
    {

        #region Unit Test Methods
        [TestMethod]
        public void ObterTodos()
        {
            Mock<INotaFiscalApp> lMock = new Mock<INotaFiscalApp>();

            lMock.Setup(x => x.FindAll()).Returns(new List<NotaFiscalVW> { new NotaFiscalVW { cnpjDestinatarioNf = 55555 } });

            var lNotaFiscalController = this.CreateController(lMock);

            var response = lNotaFiscalController.ObterTodos();

            // Asserts
            Assert.IsNotNull(response);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var lNotasFiscais = this.GetObjectContent<List<NotaFiscalVW>>(response);
            
            Assert.IsNotNull(lNotasFiscais);
            
            Assert.AreEqual(1, lNotasFiscais.Count);
        }

        [TestMethod]
        public void ObterPorId()
        {
            Mock<INotaFiscalApp> lMock = new Mock<INotaFiscalApp>();

            int id   = 55555;
            int numNF = 123;

            lMock.Setup(x => x.FindById(id)).Returns(new NotaFiscalVW { notaFiscalId = id, numeroNf = numNF});

            var lNotaFiscalController = this.CreateController(lMock);

            var response = lNotaFiscalController.ObterPorId(id);
        
            // Asserts
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var lNotaFiscal = this.GetObjectContent<NotaFiscalVW>(response);

            Assert.IsNotNull(lNotaFiscal);

            Assert.AreEqual(numNF, lNotaFiscal.numeroNf);
        }

        [TestMethod]
        public void ObterPorNumeroNF()
        {
            Mock<INotaFiscalApp> lMock = new Mock<INotaFiscalApp>();

            int id = 13432;
            long numNF = 123;
            decimal valor = 1050;

            lMock.Setup(x => x.FindByNumeroNF(numNF)).Returns(new NotaFiscalVW {dataNf = DateTime.Now, notaFiscalId = id, valorTotal = valor, numeroNf = numNF });

            var lNotaFiscalController = this.CreateController(lMock);

            var response = lNotaFiscalController.ObterPorNumeroNF(numNF);

            // Asserts
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var lNotaFiscal = this.GetObjectContent<NotaFiscalVW>(response);

            Assert.IsNotNull(lNotaFiscal);

            Assert.AreEqual(numNF, lNotaFiscal.numeroNf);
        }

        [TestMethod]
        public void Salvar()
        {
            Mock<INotaFiscalApp> lMock = new Mock<INotaFiscalApp>();

            var lNotaFiscal = new NotaFiscalVW
            {
                dataNf = DateTime.Now,
                numeroNf = 9999999,
                cnpjEmissorNf = 1234,
                cnpjDestinatarioNf = 5678,
                valorTotal = 100.00M
            };

            lMock.Setup(x => x.Persist(lNotaFiscal));

            var notaFiscalController = this.CreateController(lMock);

            var response = notaFiscalController.Salvar(lNotaFiscal);

            // Asserts
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Atualizar()
        {
            Mock<INotaFiscalApp> lMock = new Mock<INotaFiscalApp>();

            var lNotaFiscal = new NotaFiscalVW
            {
                notaFiscalId = 55555,
                dataNf = DateTime.Now,
                numeroNf = 9999999,
                cnpjEmissorNf = 1234,
                cnpjDestinatarioNf = 5678,
                valorTotal = 100.00M
            };

            lMock.Setup(x => x.Update(lNotaFiscal));

            var notaFiscalController = this.CreateController(lMock);

            var response = notaFiscalController.Atualizar(lNotaFiscal);

            // Asserts
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Remover()
        {
            Mock<INotaFiscalApp> lMock = new Mock<INotaFiscalApp>();

            int id = 5555;

            lMock.Setup(x => x.Remove(id));

            var notaFiscalController = this.CreateController(lMock);

            var response = notaFiscalController.Remover(id);

            // Asserts
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Utilities Methods

        /// <summary>
        /// Devolve uma instancia do controllador NotaFiscalController
        /// </summary>
        public NotaFiscalController CreateController(Mock<INotaFiscalApp> mock) {

            var lNotaFiscalController = new NotaFiscalController(mock.Object)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            return lNotaFiscalController;
        }

        /// <summary>
        /// Extrai o conteúdo da resposta no tipo Definido
        /// </summary>
        /// <typeparam name="TDestino">Tipo esperado do conteudo da resposta</typeparam>
        /// <param name="response"></param>
        /// <returns >TDestino</TDestino></returns>
        public TDestino GetObjectContent<TDestino>(HttpResponseMessage response)  where TDestino : class {

            var retorno = (( response.Content as ObjectContent ).Value as TDestino);

            return retorno;
        }
        #endregion

    }
}
