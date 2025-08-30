using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTest.Domain
{
    [TestClass]
    public class DomainTeste
    {
        #region Unit Test Methods
        [TestMethod]
        public void ObterTodos()
        {

            Mock<INotaFiscalRepository> lMock = new Mock<INotaFiscalRepository>();

            lMock.Setup(x => x.FindAll()).Returns(new List<NotaFiscal> { new NotaFiscal { cnpjDestinatarioNf = 55555 } });

            var lNotaFiscalService = new NotaFiscalService(lMock.Object);

            var lNotasFiscais = lNotaFiscalService.FindAll();

            Assert.IsNotNull(lNotasFiscais);
            Assert.AreEqual(1, lNotasFiscais.ToList().Count);
        }

        [TestMethod]
        public void ObterPorId()
        {
            Mock<INotaFiscalRepository> lMock = new Mock<INotaFiscalRepository>();

            int id = 55555;
            long numNF = 123;

            lMock.Setup(x => x.FindById(id)).Returns(new NotaFiscal { notaFiscalId = id, numeroNf = numNF, dataNf = DateTime.Now });

            var lNotaFiscalApp = new NotaFiscalService(lMock.Object);

            var lNotaFiscal = lNotaFiscalApp.FindById(id);

            Assert.IsNotNull(lNotaFiscal);

            Assert.AreEqual(numNF, lNotaFiscal.numeroNf);

        }

        [TestMethod]
        public void ObterPorNumeroNF()
        {
            Mock<INotaFiscalRepository> lMock = new Mock<INotaFiscalRepository>();

            int id = 13432;
            long numNF = 123;
            decimal valor = 1050;

            lMock.Setup(x => x.FindByNumeroNF(numNF)).Returns(new NotaFiscal { dataNf = DateTime.Now, notaFiscalId = id, valorTotal = valor, numeroNf = numNF });

            var lNotaFiscalApp = new NotaFiscalService(lMock.Object);

            var lNotaFiscal = lNotaFiscalApp.FindByNumeroNF(numNF);

            Assert.IsNotNull(lNotaFiscal);

            Assert.AreEqual(numNF, lNotaFiscal.numeroNf);

        }

        [TestMethod]
        public void Salvar()
        {
            Mock<INotaFiscalRepository> lMock = new Mock<INotaFiscalRepository>();

            // Entity
            var lNotaFiscal = new NotaFiscal
            {
                dataNf = DateTime.Now,
                numeroNf = 9999999,
                cnpjEmissorNf = 1234,
                cnpjDestinatarioNf = 5678,
                valorTotal = 100.00M
            };

            lMock.Setup(x => x.Persist(lNotaFiscal));

            var lNotaFiscalApp = new NotaFiscalService(lMock.Object);

            lNotaFiscalApp.Persist(lNotaFiscal);

        }

        [TestMethod]
        public void Atualizar()
        {
            Mock<INotaFiscalRepository> lMock = new Mock<INotaFiscalRepository>();

            // Entity
            var lNotaFiscal = new NotaFiscal
            {
                dataNf = DateTime.Now,
                numeroNf = 9999999,
                cnpjEmissorNf = 1234,
                cnpjDestinatarioNf = 5678,
                valorTotal = 100.00M
            };

            lMock.Setup(x => x.Update(lNotaFiscal));

            var lNotaFiscalApp = new NotaFiscalService(lMock.Object);

            lNotaFiscalApp.Update(lNotaFiscal);

        }

        [TestMethod]
        public void Remover()
        {
            Mock<INotaFiscalRepository> lMock = new Mock<INotaFiscalRepository>();

            int id = 5555;

            lMock.Setup(x => x.Remove(id));

            var lNotaFiscalApp = new NotaFiscalService(lMock.Object);

            lNotaFiscalApp.Remove(id);
        }
        #endregion

        #region Utilities Methods


        #endregion
    }
}
