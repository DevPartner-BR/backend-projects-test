using Application.Interfaces;
using Application.Model;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation.Results;

namespace Application.App
{
    public class NotaFiscalApplication : INotaFiscalApplication
    {

        #region Objetos/Variáveis Locais

        protected readonly IUnitOfWork _uow;
        protected readonly INotaFiscalService _service;

        #endregion

        #region Construtores

        /// <summary>
        /// Crima uma nova instância da aplicação de nota fiscal
        /// </summary>
        public NotaFiscalApplication
        (
            IUnitOfWork uow,
            INotaFiscalService service
        )
        {
            _uow = uow;
            _service = service;
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Busca um registro de nota com base no Id ou número
        /// </summary>
        /// <param name="view">ViewModel de nota fiscal</param>
        private NotaFiscal BuscarNota(Guid? id, int numeroNf)
        {
            NotaFiscal nota = null;
            if (id.HasValue)
                nota = _service.ObterPorId(id.Value);
            if (!id.HasValue && nota == null)
                nota = _service.ObterPorNumeroNf(numeroNf);
            return nota;
        }

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Adicionar um registro de nota fiscal
        /// </summary>
        /// <param name="view">Nota fiscal a ser adicionada</param>
        public NotaFiscalViewModel Adicionar(NotaFiscalViewModel view)
        {

            NotaFiscal nota = Mapper.Map<NotaFiscal>(view);

            if (!nota.EstaValido())
            {
                view.AdicionarCriticas(nota.ValidationResult.Errors);
                return view;
            }
            else
            {
                _service.Adicionar(nota);
                _uow.SalvarMudancas();
                return Mapper.Map<NotaFiscalViewModel>(nota);
            }


        }

        /// <summary>
        /// Busca um registro de nota fiscal pelo id
        /// </summary>
        /// <param name="id">Id da nota fiscal</param>
        public NotaFiscalViewModel ObterPorId(Guid id)
        {
            NotaFiscal nota = _service.ObterPorId(id);
            if (nota == null)
                return null;
            return Mapper.Map<NotaFiscalViewModel>(nota);
        }

        /// <summary>
        /// Busca um registro de nota fiscal pelo número da nota
        /// </summary>
        /// <param name="id">Número da nota fiscal</param>
        public NotaFiscalViewModel ObterPorNumeroNf(int numeroNF)
        {
            NotaFiscal nota = _service.ObterPorNumeroNf(numeroNF);
            if (nota == null)
                return null;
            return Mapper.Map<NotaFiscalViewModel>(nota);
        }

        /// <summary>
        /// Obter todos os registros de notas fiscais
        /// </summary>
        public IEnumerable<NotaFiscalViewModel> ObterTodos()
        {
            IEnumerable<NotaFiscal> notas = _service.ObterTodos();
            if (notas == null)
                return null;
            return Mapper.Map<IEnumerable<NotaFiscalViewModel>>(notas);
        }

        /// <summary>
        /// Atualizar um registro de uma nota fiscal
        /// </summary>
        /// <param name="view">ViewModel da entidade a ser atualizada</param>
        public NotaFiscalViewModel Atualizar(NotaFiscalViewModel view)
        {
            
            if (!view.Id.HasValue && view.NumeroNf <= 0)
            {
                view.AdicionarCriticas(new List<ValidationFailure> { new ValidationFailure("Id/NumeroNF", "O Id ou número da nota fiscal deve ser informado") });
                return view;
            }
            else
            {

                NotaFiscal nota = BuscarNota(view.Id, view.NumeroNf);
                if (nota == null)
                {
                    view.AdicionarCriticas(new List<ValidationFailure> { new ValidationFailure("Nota", "Nota fiscal não encontrada") });
                    return view;
                }
                else
                {

                    // Os campos Id, Número e Data não são atualizáveis por regra de negócio
                    nota.ValorTotal = view.ValorTotal;
                    nota.CnpjEmissorNf = view.CnpjEmissorNf;
                    nota.CnpjDestinatarioNf = view.CnpjDestinatarioNf;

                    _service.Atualizar(nota);
                    _uow.SalvarMudancas();
                    return Mapper.Map<NotaFiscalViewModel>(nota);
                }

            }

        }

        /// <summary>
        /// Excluir o registro de uma nota fiscal
        /// </summary>
        /// <param name="id">Id da nota fiscal a ser excluída</param>
        public void Excluir(Guid id)
        {
            NotaFiscal nota = BuscarNota(id, 0);
            if (nota != null)
            {
                _service.Excluir(id);
                _uow.SalvarMudancas();
            }
        }

        #endregion

    }
}
