using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.Infrastructure;
using AutoMapper;
using Domain.Entities;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NotaFiscalController : AppControllerBase
    {
        public AppDbContext Context { get; }

        public NotaFiscalController(AppDbContext context)
        {
            Context = context;
        }

        // [note] Endpoint to create a "Nota Fiscal"
        [HttpPost]
        public async Task<IActionResult> Create(NotaFiscalCreate nfCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // [note] This response could be 422 - Unprocessable Entity
            //
            var nf = Mapper.Map<NotaFiscalCreate, NotaFiscal>(nfCreate);
            // [note] Filling values the client mustn't supply, to preserve the data integrity
            nf.DataNF = DateTime.Now;
            nf.NotaFiscalId = Guid.NewGuid();
            try
            {
                // [note] Saving to database
                await Context.NotasFiscais.AddAsync(nf);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return InternalServerError(ResponseConstants.MessageDbConnectionFailed);
            }
            // [note] Returning the created value with 201 - Created
            var nfList = Mapper.Map<NotaFiscal, NotaFiscalList>(nf);
            return CreatedAtAction(nameof(Get), new[] {nf.NotaFiscalId}, nfList);
        }

        // [note] Endpoint to recover all NotasFiscais
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var nfArray = Context
                        .NotasFiscais
                        .AsNoTracking()
                        .ToArray();
                var nfListArray = Mapper.Map<NotaFiscal[], NotaFiscalList[]>(nfArray);
                return Ok(nfListArray);
            }
            catch (Exception)
            {
                return InternalServerError(ResponseConstants.MessageDbConnectionFailed);
            }
        }

        // [note] Endpoint to recover a specific NotaFiscal by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([Required] Guid id)
        {
            try
            {
                var nf = await Context
                        .NotasFiscais
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.NotaFiscalId == id);
                if (nf is null)
                    return NotFound(
                        new ResponseDescriptor<string>()
                        {
                            Message = ResponseConstants.NotFound,
                            Result = $"{nameof(NotaFiscal)} {id} wasn't found",
                        }
                    );
                var nfList = Mapper.Map<NotaFiscal, NotaFiscalList>(nf);
                return Ok(nfList);
            }
            catch (Exception)
            {
                return InternalServerError(ResponseConstants.MessageDbConnectionFailed);
            }
        }

        // [note] Endpoint to delete a specific NotaFiscal by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] Guid id)
        {
            try
            {
                var nf = await Context.NotasFiscais.FindAsync(id);
                if (nf is null)
                    return NotFound(
                        new ResponseDescriptor<string>()
                        {
                            Message = ResponseConstants.NotFound,
                            Result = $"{nameof(NotaFiscal)} {id} wasn't found",
                        }
                    );
                // Updating database
                Context.NotasFiscais.Remove(nf);
                await Context.SaveChangesAsync();
                return Ok(
                    new ResponseDescriptor<string>()
                    {
                        Message = ResponseConstants.Deleted,
                        Result = $"{nameof(NotaFiscal)} {id} was deleted",
                    }
                );
            }
            catch (Exception)
            {
                return InternalServerError(ResponseConstants.MessageDbConnectionFailed);
            }
        }

        // [note] Endpoint updates a NotaFiscal by Id, but the fields weren't specified, then I allowed users to update the same fields they can provide to create a NotaFiscal.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] Guid id, NotaFiscalUpdate nfUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                // Recovering NotaFiscal from database
                var nf = await Context.NotasFiscais.FindAsync(id);
                if (nf is null)
                    return NotFound(
                        new ResponseDescriptor<string>()
                        {
                            Message = ResponseConstants.NotFound,
                            Result = $"{nameof(NotaFiscal)} {id} wasn't found",
                        }
                    );
                // [note] Update fields from client NotaFiscal to database NotaFiscal
                nf.CNPJDestinatarioNF = nfUpdate.CNPJDestinatarioNF;
                nf.CNPJEmissorNF = nfUpdate.CNPJEmissorNF;
                nf.ValorTotal = nfUpdate.ValorTotal;
                // Updating database
                Context.NotasFiscais
                    .Update(nf)
                    .Property(x => x.NumeroNF).IsModified = false;
                await Context.SaveChangesAsync();
                // Converting NotaFiscal to Response
                var nfList = Mapper.Map<NotaFiscal, NotaFiscalList>(nf);
                return Ok(nfList);
            }
            catch (Exception)
            {
                return InternalServerError(ResponseConstants.MessageDbConnectionFailed);
            }
        }
    }
}