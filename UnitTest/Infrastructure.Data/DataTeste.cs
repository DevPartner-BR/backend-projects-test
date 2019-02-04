using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Context;
using Data.Repositories;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTest.Infrastructure.Data
{
    [TestClass]
    public class DataTeste
    {
        #region Unit Test Methods
        [TestMethod]
        public void ObterTodos()
        {

            Mock<DbSet<NotaFiscal>> lMockDbSet = new Mock<DbSet<NotaFiscal>>();

            Mock<SystemContext> lMock = GetMockContext(lMockDbSet);

            var notaFiscalRepository = new NotaFiscalRepository(lMock.Object);

            var lNotasFiscais = notaFiscalRepository.FindAll();

            Assert.IsNotNull(lNotasFiscais);

            Assert.AreEqual(2, lNotasFiscais.ToList().Count);
        }


        [TestMethod]
        public void ObterPorId()
        {
            int id = 2;
            long numNF = 123;

            Mock<DbSet<NotaFiscal>> lMockDbSet= new Mock<DbSet<NotaFiscal>>();

            lMockDbSet.Setup(x => x.Find(id)).Returns(new NotaFiscal { notaFiscalId = 2, numeroNf = 123});

            Mock<SystemContext> lMock = GetMockContext(lMockDbSet);

            var lNotaFiscalRepository = new NotaFiscalRepository(lMock.Object);

            var lNotaFiscal = lNotaFiscalRepository.FindById(id);

            Assert.IsNotNull(lNotaFiscal);

            Assert.AreEqual(numNF, lNotaFiscal.numeroNf);

        }

        #endregion

        #region Utilities Methods
        private static Mock<SystemContext> GetMockContext(Mock<DbSet<NotaFiscal>> mockSet)
        {
            Mock<SystemContext> lMock = new Mock<SystemContext>();

            
            var data = new List<NotaFiscal>
            {
                new NotaFiscal { notaFiscalId = 1, cnpjEmissorNf = 983897, cnpjDestinatarioNf = 1652454, dataNf = DateTime.Now, numeroNf = 123456},
                new NotaFiscal { notaFiscalId = 2, cnpjEmissorNf = 9838, cnpjDestinatarioNf = 1652989754, dataNf = DateTime.Now, numeroNf = 123 }

            }.AsQueryable();


            mockSet.As<IQueryable<NotaFiscal>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<NotaFiscal>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<NotaFiscal>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<NotaFiscal>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            lMock.Setup(c => c.NotaFiscal).Returns(mockSet.Object);
            return lMock;
        }
        #endregion
    }
}
