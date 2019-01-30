using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class NotaFiscalService
    {
        INotaFiscalRepository NotaFiscalRep { get; }

        public NotaFiscalService(INotaFiscalRepository _notaFiscalRep)
        {
            NotaFiscalRep = _notaFiscalRep;
        }

        public string CriarNota(NotaFiscal _entity)
        {
            NotaFiscalRep.Add(_entity);

            return "Nota inserida com sucesso";
        }

        public string AlterarNota(NotaFiscal _entity)
        {
            NotaFiscalRep.Update(_entity);

            return "Nota alterada com sucesso";
        }

        public string ExcluirNota(NotaFiscal _entity)
        {
            var selected = NotaFiscalRep.Get<int>(_entity.notaFiscalId);

            NotaFiscalRep.Remove(selected);

            return "Nota excluída com sucesso";
        }

        public IList<NotaFiscal> ExibirNotas()
        {
            IList<NotaFiscal> notas = NotaFiscalRep.GetAll();

            return notas;
        }

        public NotaFiscal ExibirNota(int _id)
        {
            NotaFiscal nota = NotaFiscalRep.Get<int>(_id);

            return nota;
        }
    }
}
