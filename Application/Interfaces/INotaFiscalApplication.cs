using Application.Model;

namespace Application.Interfaces
{
    public interface INotaFiscalApplication : IApplicationCrud<NotaFiscalViewModel>
    {

        /// <summary>
        /// Obter registro pelo número da NF
        /// </summary>
        /// <param name="numeroNF">Número da NF</param>
        NotaFiscalViewModel ObterPorNumeroNf(int numeroNF);

    }
}
