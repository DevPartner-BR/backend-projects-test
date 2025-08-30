using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class NotaFiscalService : ServiceBase<NotaFiscal>, INotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository)
            : base(notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }
    }
}