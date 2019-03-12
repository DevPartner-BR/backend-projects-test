using AutoFixture;
using Data.Dapper;
using Domain.Entities;
using Xunit;

namespace Testes
{
    public class NotaFiscalTestes
    {
        private readonly NotaFiscalRepository _objRepo;

        public NotaFiscalTestes()
        {
            _objRepo = new NotaFiscalRepository();
        }

        [Fact]
        public void InsereNota()
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new MaxLengthAttributeRelay());

            var nf = fixture.Create<NotaFiscal>();

            Assert.True(_objRepo.InsereNotaFiscal(nf));
        }

        [Fact]
        public void ListaNotas()
        {
            var ret = _objRepo.RetornaListaNotas();
            Assert.True(ret.Count > 0);
        }
    }
}