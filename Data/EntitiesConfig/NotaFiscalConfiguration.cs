using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntitiesConfig
{
    public class NotaFiscalConfiguration : EntityTypeConfiguration<NotaFiscal>
    {
        public NotaFiscalConfiguration()
        {
            HasKey(t => new { t.notaFiscalId });
        }
    }
}
