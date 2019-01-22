using System.Data.Entity;
using UsuarioDomain.Interfaces.Repository;

namespace Data.Context
{
    public class UsuarioUnitOfWork : IUsuarioUnitOfWork
    {
        public DbContext GetContext()
        {
            return new SystemContext();
        }
    }
}
