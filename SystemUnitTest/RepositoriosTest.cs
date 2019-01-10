using System;
using Data.Context;
using Data.Repositories;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SystemUnitTest
{
    [TestClass]
    public class RepositoriosTest
    {

        [TestMethod]
        public void ContextInstanciar()
        {

            SystemContext ctx = new SystemContext();
            Assert.IsNotNull(ctx);

        }

        #region Entidade Nota Fiscal

        [TestMethod]
        public void NotaFiscalInstanciar()
        {
            NotaFiscalRepository rep = new NotaFiscalRepository(new SystemContext());
            Assert.IsNotNull(rep);
        }

        [TestMethod]
        public void EntidadeNFValidacaoOk()
        {

            NotaFiscal nota = new NotaFiscal();
            nota.NumeroNf = 2147483647;
            nota.CnpjEmissorNf = "03615099000124";
            nota.CnpjDestinatarioNf = "70165745000196";
            nota.ValorTotal = 1999;
            nota.DataNf = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            Assert.IsTrue(nota.EstaValido());
        }

        [TestMethod]
        public void EntidadeNFValidacaoCritica()
        {

            NotaFiscal nota = new NotaFiscal();
            Assert.IsFalse(nota.EstaValido());
        }

        //[TestMethod]
        //public void NotaFiscalAdicionar()
        //{
        //    Guid? notaId = null;
        //    NotaFiscalRepository rep = new NotaFiscalRepository(new SystemContext());

        //    NotaFiscal nota = new NotaFiscal();
        //    notaId = nota.Id;
        //    nota.NumeroNf = 2147483647;
        //    nota.CnpjEmissorNf = "03615099000124";
        //    nota.CnpjDestinatarioNf = "70165745000196";
        //    nota.ValorTotal = 1999;
        //    nota.DataNf = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

        //    Assert.IsTrue(nota.EstaValido());

        //    rep.Adicionar(nota);

        //    Assert.IsTrue(true);
        //}

        #endregion

    }
}
