using Data.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Domain.Entities;
using Domain.Interfaces.Repository;

namespace Data.Repositories
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private SystemContext _context = new SystemContext();

        public void Persist(NotaFiscal notaFiscal)
        {
            _context.NotaFiscal.Add(notaFiscal);
            _context.SaveChanges();
        }

        public NotaFiscal FindById(int id)
        {
            return _context.NotaFiscal.Find(id);
        }

        public NotaFiscal FindByNumeroNF(long numNF) {
            return _context.NotaFiscal
                .Where(nf=> nf.numeroNf == numNF)
                .FirstOrDefault<NotaFiscal>();
        }

        public IEnumerable<NotaFiscal> FindAll()
        {
            IEnumerable<NotaFiscal> NotasFiscais = _context.NotaFiscal;
            return NotasFiscais;
        }

        public void Update(NotaFiscal notaFiscal)
        {
            _context.Entry(notaFiscal).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            NotaFiscal lNotaFiscal = new NotaFiscal() { notaFiscalId = id };
            _context.NotaFiscal.Attach(lNotaFiscal);
            _context.Entry(lNotaFiscal).State = EntityState.Deleted;
            _context.SaveChanges();

        }

    }
}
