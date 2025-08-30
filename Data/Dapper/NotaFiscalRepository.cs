using Dapper;
using Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Data.Dapper
{
    public class NotaFiscalRepository : BaseRepository, INotaFiscalRepository
    {
        public List<NotaFiscal> RetornaListaNotas()
        {
            List<NotaFiscal> ret;
            using (var db = new SqlConnection(Connstring))
            {
                const string sql = @"SELECT notaFiscalId, numeroNf, valorTotal, dataNf, cnpjEmissorNf, cnpjDestinatarioNf from NotaFiscal";

                ret = db.Query<NotaFiscal>(sql, commandType: CommandType.Text).ToList();
            }

            return ret;
        }

        public bool InsereNotaFiscal(NotaFiscal notaFiscal)
        {
            using (var db = new SqlConnection(Connstring))
            {
                const string sql = @"INSERT INTO NotaFiscal (numeroNf, valorTotal, dataNf, cnpjEmissorNf, cnpjDestinatarioNf) VALUES (@numeroNf, @valorTotal, @dataNf, @cnpjEmissorNf, @cnpjDestinatarioNf) ";

                db.Execute(sql, new { notaFiscal.numeroNf, notaFiscal.valorTotal, notaFiscal.dataNf, notaFiscal.cnpjEmissorNf, notaFiscal.cnpjDestinatarioNf }, commandType: CommandType.Text);
            }
            return true;
        }

        public bool AtualizaNotaFiscal(NotaFiscal notaFiscal)
        {
            using (var db = new SqlConnection(Connstring))
            {
                const string sql = @"UPDATE NotaFiscal SET numeroNf = @numeroNf, valorTotal = @valorTotal, dataNf = @dataNf, cnpjEmissorNf = @cnpjEmissorNf, cnpjDestinatarioNf = @cnpjDestinatarioNf WHERE notaFiscalId = @notaFiscalId";

                db.Execute(sql, new { notaFiscal.notaFiscalId, notaFiscal.numeroNf, notaFiscal.valorTotal, notaFiscal.dataNf, notaFiscal.cnpjEmissorNf, notaFiscal.cnpjDestinatarioNf }, commandType: CommandType.Text);
            }
            return true;
        }

        public bool ExcluiNotaFiscal(NotaFiscal notaFiscal)
        {
            using (var db = new SqlConnection(Connstring))
            {
                const string sql = @"DELETE FROM NotaFiscal WHERE notaFiscalId = @notaFiscalId";

                db.Execute(sql, new { notaFiscal.notaFiscalId }, commandType: CommandType.Text);
            }
            return true;
        }
    }
}