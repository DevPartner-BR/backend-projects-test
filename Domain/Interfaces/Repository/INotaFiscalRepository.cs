using Domain.Entities;

namespace Domain.Interfaces.Repository
{
    public interface INotaFiscalRepository : IRepositoryBase<NotaFiscal>
    {

        /// <summary>
        /// Obter registro pelo número da NF
        /// </summary>
        /// <param name="numeroNF">Número da NF</param>
        NotaFiscal ObterPorNumeroNf(int numeroNF);

    }
}
