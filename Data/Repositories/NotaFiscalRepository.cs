using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repositories
{
    public class NotaFiscalRepository : Repository<NotaFiscal>, INotaFiscalRepository
    {
        public NotaFiscalRepository(SystemContext _context) : base(_context)
        {
        }
    }
}
