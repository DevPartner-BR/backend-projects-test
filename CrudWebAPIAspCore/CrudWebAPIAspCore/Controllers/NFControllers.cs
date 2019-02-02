using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudWebAPIAspCore.Model;
using CrudWebAPIAspCore.Service;

namespace CrudWebAPIAspCore.Controllers
{
    [Route("NotasFiscais")]
    public class NFControllers :Controller
    {
        private readonly INFService service;
        public NFControllers(INFService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<NotaFiscal> model = service.GetNotaFiscal();
            var outputModel = ToOutputModelList(model);
            return Ok(outputModel);
        }

        [HttpGet("{notafiscalid}", Name = "GetFilme")]
        public IActionResult Get(int notafiscalid)
        {
            var model = service.GetNotaFiscal(notafiscalid);
            if (model == null)
                return NotFound();

            var outputModel = ToOutPutModel(model);
            return Ok(outputModel);         
        }
        [HttpPost]
        public IActionResult Create([FromBody]NFInput inputModel)
        {
            if (inputModel == null)
                return BadRequest();
            var model = ToDomainModel(inputModel);
            service.AddNotaFiscal(model);
            var outputModel = ToOutPutModel(model);
            return CreatedAtRoute("GetFilme", new { notafiscalid = outputModel.notaFiscalId }, outputModel);
        }
        [HttpPut("{notafiscalid}")]
        public IActionResult Update(int notafiscalid, [FromBody]NFInput inputmodel )
        {
            if (inputmodel == null || notafiscalid != inputmodel.notaFiscalId)
                return BadRequest();
            if (!service.NotaFiscalExiste(notafiscalid))
                return NotFound();
            var model = ToDomainModel(inputmodel);
            service.UpdateNotaFiscal(model);
            return NoContent();

        }
        [HttpDelete("{notafiscalid}")]
        public IActionResult Delete(int notafiscalid)
        {
            if (!service.NotaFiscalExiste(notafiscalid))
                return NotFound();
            service.DeletaNotaFiscal(notafiscalid);
            return NoContent();
        }
        //Mapeamentos: modelo de envia/receber dados via API
        private NFOutput ToOutPutModel(NotaFiscal model)
        {
            return new NFOutput
            {
                notaFiscalId = model.notaFiscalId,
                numeroNf = model.numeroNf,
                cnpjEmissorNf = model.cnpjEmissorNf,
                valorTotal = model.valorTotal,
                dataNf = model.dataNf,
               cnpjDestinatarioNf= model.cnpjDestinatarioNf
            };
        }
        private  List<NFOutput> ToOutputModelList(List<NotaFiscal> model)
        {
            return model.Select(item => ToOutPutModel(item)).ToList();
        }
        private NotaFiscal ToDomainModel(NFInput inputModel)
        {
            return new NotaFiscal
            {
                notaFiscalId = inputModel.notaFiscalId,
                numeroNf = inputModel.numeroNf,
                dataNf = inputModel.dataNf,
                valorTotal = inputModel.valorTotal,
                cnpjDestinatarioNf = inputModel.cnpjDestinatarioNf,
                cnpjEmissorNf = inputModel.cnpjEmissorNf
            };
        }
        private NFInput ToInputModel(NotaFiscal model)
        {
            return new NFInput
            {
                notaFiscalId = model.notaFiscalId,
                numeroNf = model.numeroNf,
                dataNf = model.dataNf,
                valorTotal = model.valorTotal,
                cnpjDestinatarioNf = model.cnpjDestinatarioNf,
                cnpjEmissorNf = model.cnpjEmissorNf
            };
        }
        }
    }

