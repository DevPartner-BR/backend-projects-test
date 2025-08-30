using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudWebAPIAspCore.Model;



namespace CrudWebAPIAspCore.Service
{
    public class NFService: INFService
    {
        private readonly List<NotaFiscal> notaFiscals;
        public NFService()
        {
            this.notaFiscals = new List<NotaFiscal>
            {
                new NotaFiscal{notaFiscalId= 1, numeroNf = 1, dataNf = DateTime.Today.AddDays(1), valorTotal = 310.00f, cnpjDestinatarioNf = "30.126.492/0001-27", cnpjEmissorNf = "05.918.500/0001-20"},
                new NotaFiscal{notaFiscalId= 2, numeroNf = 2, dataNf = DateTime.Today.AddDays(2), valorTotal = 311.00f, cnpjDestinatarioNf = "30.126.492/0001-27", cnpjEmissorNf = "05.918.500/0001-20"},
                new NotaFiscal{notaFiscalId= 3, numeroNf = 3, dataNf = DateTime.Today.AddDays(3), valorTotal = 312.00f, cnpjDestinatarioNf = "30.126.492/0001-27", cnpjEmissorNf = "05.918.500/0001-20"} };
            }
        public void AddNotaFiscal(NotaFiscal item) {
            this.notaFiscals.Add(item);
            }
        public void DeletaNotaFiscal(int notafiscalid)
        {
            var model = this.notaFiscals.Where(m => m.notaFiscalId == notafiscalid).FirstOrDefault();
            this.notaFiscals.Remove(model);
        }
        public bool NotaFiscalExiste(int notafiscalid)
        {
            return this.notaFiscals.Any(m => m.notaFiscalId == notafiscalid);
        }
        public  NotaFiscal GetNotaFiscal(int notafiscalid)
        {
            return this.notaFiscals.Where(m => m.notaFiscalId == notafiscalid).FirstOrDefault();
        }
        public List<NotaFiscal> GetNotaFiscal()
        {
            return this.notaFiscals.ToList();
        }
        public void UpdateNotaFiscal(NotaFiscal item)
        {
            var model = this.notaFiscals.Where(m => m.notaFiscalId == item.notaFiscalId).FirstOrDefault();
            model.dataNf = item.dataNf;
            model.cnpjDestinatarioNf = item.cnpjDestinatarioNf;
            model.cnpjEmissorNf = model.cnpjEmissorNf;
            model.valorTotal = model.valorTotal;
            model.numeroNf = model.numeroNf;
        }
    }
    }

