using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class TipoEmpresaUnitOfWork : ITipoEmpresaUnitOfWork
    {
        public DbContext GetContext()
        {
            return new SystemContext();
        }
    }
}
