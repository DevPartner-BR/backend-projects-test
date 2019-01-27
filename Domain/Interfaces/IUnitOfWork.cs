using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       
        INotaFiscalRepository NotaFiscalRepository { get; }

        bool BeginTransaction();
        bool SaveChanges();
        bool Rollback();
        int Complete();
    }
}
