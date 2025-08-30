using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application
{
    public class NotaFiscalAppService : AppServiceBase<NotaFiscal>, INotaFiscalAppService
    {
        private readonly INotaFiscalService _notaFiscalService;

        public NotaFiscalAppService(INotaFiscalService notaFiscalService)
            : base(notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }
    }
}