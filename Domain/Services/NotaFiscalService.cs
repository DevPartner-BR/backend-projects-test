using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class NotaFiscalService : ServiceBase<NotaFiscal, INotaFiscalRepository>, INotaFiscalService
    {

        #region Construtores

        /// <summary>
        /// Cria uma nova instância do serviço de domínio de nota fiscal
        /// </summary>
        /// <param name="repository">Repositório da entidade de nota fiscal</param>
        public NotaFiscalService(INotaFiscalRepository repository) : base(repository) { }

        #endregion

        #region Métodos Públicos


        /// <summary>
        /// Obter nota fiscal pelo número da mesma
        /// </summary>
        /// <param name="numeroNF">Número da nota fiscal</param>
        public NotaFiscal ObterPorNumeroNf(int numeroNF)
        {
            if (numeroNF <= 0)
                return null;
            return _repository.ObterPorNumeroNf(numeroNF);
        }

        #endregion

    }
}
