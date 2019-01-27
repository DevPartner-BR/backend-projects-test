using Domain.Interfaces;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private SystemContext Context;

        private IDbConnection DbConnection;

        private IDbTransaction DbTransaction;

        public INotaFiscalRepository NotaFiscalRepository { get; private set; }

        public UnitOfWork(INotaFiscalRepository _notaFiscalRepository, SystemContext _context)
        {

            Context = _context;
            Context.Configuration.AutoDetectChangesEnabled = true;
            Context.Configuration.LazyLoadingEnabled = true;
            DbConnection = Context.Database.Connection;
            NotaFiscalRepository = _notaFiscalRepository;
        }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public bool BeginTransaction()
        {
            try
            {
                DbTransaction = Context.Database.BeginTransaction().UnderlyingTransaction;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Rollback()
        {
            try
            {
                DbTransaction.Rollback();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool SaveChanges()
        {
            try
            {
                DbTransaction.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            Context.Dispose();

            DbConnection.Dispose();

            if (DbTransaction != null)
            {
                DbTransaction.Dispose();
            }
        }
    }
}
