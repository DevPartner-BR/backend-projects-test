using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application
{
    public class NotaFiscalAppService : AppServiceBase<NotaFiscal>, INotaFiscalAppService
    {
        private readonly INotaFiscalService _clienteService;

        public NotaFiscalAppService(INotaFiscalService clienteService) : base(clienteService)
        {
            _clienteService = clienteService;
        }

    }
}
