using System;
using System.Collections.Generic;
using System.Linq;
using Application.App;
using Application.AutoMapper;
using Application.Model;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTest.Application
{
    [TestClass]
    public class ApplicationTeste
    {
        #region Unit Test Methods
        [TestMethod]
        public void ObterTodos()
        {
            AutoMapperConfig.Reset();
            AutoMapperConfig.RegisterMappings();

            Mock<INotaFiscalService> lMock = new Mock<INotaFiscalService>();

            lMock.Setup(x => x.FindAll()).Returns(new List<NotaFiscal> { new NotaFiscal { cnpjDestinatarioNf = 55555 } });

            var notaFiscalApp = new NotaFiscalApp(lMock.Object);

            var lNotasFiscais = notaFiscalApp.FindAll();

            Assert.IsNotNull(lNotasFiscais);
            Assert.AreEqual(1, lNotasFiscais.ToList().Count);
        }

        [TestMethod]
        public void ObterPorId()
        {
            AutoMapperConfig.Reset();
            AutoMapperConfig.RegisterMappings();

            Mock<INotaFiscalService> lMock = new Mock<INotaFiscalService>();

            int id = 55555;
            long numNF = 123;

            lMock.Setup(x => x.FindById(id)).Returns(new NotaFiscal { notaFiscalId = id, numeroNf = numNF, dataNf = DateTime.Now });

            var lNotaFiscalApp = new NotaFiscalApp(lMock.Object);

            var lNotaFiscal = lNotaFiscalApp.FindById(id);

            Assert.IsNotNull(lNotaFiscal);

            Assert.AreEqual(numNF, lNotaFiscal.numeroNf);
            
        }

        [TestMethod]
        public void ObterPorNumeroNF()
        {
            AutoMapperConfig.Reset();
            AutoMapperConfig.RegisterMappings();

            Mock<INotaFiscalService> lMock = new Mock<INotaFiscalService>();

            int id = 13432;
            long numNF = 123;
            decimal valor = 1050;

            lMock.Setup(x => x.FindByNumeroNF(numNF)).Returns(new NotaFiscal { dataNf = DateTime.Now, notaFiscalId = id, valorTotal = valor, numeroNf = numNF });

            var lNotaFiscalApp = new NotaFiscalApp(lMock.Object);

            var lNotaFiscal = lNotaFiscalApp.FindByNumeroNF(numNF);

            Assert.IsNotNull(lNotaFiscal);

            Assert.AreEqual(numNF, lNotaFiscal.numeroNf);

        }

        [TestMethod]
        public void Salvar()
        {
            AutoMapperConfig.Reset();
            AutoMapperConfig.RegisterMappings();

            Mock<INotaFiscalService> lMock = new Mock<INotaFiscalService>();

            // VW
            var lNotaFiscalVW = new NotaFiscalVW
            {
                dataNf              = DateTime.Now,
                numeroNf            = 9999999,
                cnpjEmissorNf       = 1234,
                cnpjDestinatarioNf  = 5678,
                valorTotal          = 100.00M
            };

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

            var lNotaFiscalApp = new NotaFiscalApp(lMock.Object);

            lNotaFiscalApp.Persist(lNotaFiscalVW);

        }

        [TestMethod]
        public void Atualizar()
        {
            AutoMapperConfig.Reset();
            AutoMapperConfig.RegisterMappings();

            Mock<INotaFiscalService> lMock = new Mock<INotaFiscalService>();

            // VW
            var lNotaFiscalVW = new NotaFiscalVW
            {
                dataNf = DateTime.Now,
                numeroNf = 9999999,
                cnpjEmissorNf = 1234,
                cnpjDestinatarioNf = 5678,
                valorTotal = 100.00M
            };

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

            var lNotaFiscalApp = new NotaFiscalApp(lMock.Object);

            lNotaFiscalApp.Update(lNotaFiscalVW);

        }

        [TestMethod]
        public void Remover()
        {
            AutoMapperConfig.Reset();
            AutoMapperConfig.RegisterMappings();

            Mock<INotaFiscalService> lMock = new Mock<INotaFiscalService>();

            int id = 5555;

            lMock.Setup(x => x.Remove(id));

            var lNotaFiscalApp = new NotaFiscalApp(lMock.Object);

            lNotaFiscalApp.Remove(id);
        }
        #endregion

        #region Utilities Methods
        

        #endregion

    }
}
