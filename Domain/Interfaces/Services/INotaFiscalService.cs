using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface INotaFiscalService : IServiceBase<NotaFiscal>
    {

        /// <summary>
        /// Obter registro pelo número da NF
        /// </summary>
        /// <param name="numeroNF">Número da NF</param>
        NotaFiscal ObterPorNumeroNf(int numeroNF);

    }
}
