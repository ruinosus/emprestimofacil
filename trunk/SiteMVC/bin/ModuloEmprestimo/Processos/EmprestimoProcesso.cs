using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloEmprestimo.Repositorios;
using SiteMVC.ModuloEmprestimo.Processos;
using SiteMVC.ModuloEmprestimo.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloEmprestimo.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloParcela.Processos;
using SiteMVC.ModuloPrazoPagamento.Processos;
using SiteMVC.ModuloLancamento.Processos;

namespace SiteMVC.ModuloEmprestimo.Processos
{
    /// <summary>
    /// Classe EmprestimoProcesso
    /// </summary>
    public class EmprestimoProcesso : Singleton<EmprestimoProcesso>, IEmprestimoProcesso
    {
        #region Atributos
        private IEmprestimoRepositorio emprestimoRepositorio = null;
        #endregion

        #region Construtor
        public EmprestimoProcesso()
        {
            emprestimoRepositorio = EmprestimoFabrica.IEmprestimoInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(Emprestimo emprestimo)
        {

            this.emprestimoRepositorio.Incluir(emprestimo);
            this.Confirmar();
            IParcelaProcesso parcelaProcesso = ParcelaProcesso.Instance;
            IPrazoPagamentoProcesso prazoPagamentoProcesso = PrazoPagamentoProcesso.Instance;

            PrazoPagamento prazo = new PrazoPagamento();
            prazo.ID = emprestimo.prazospagamento_id;

            prazo = prazoPagamentoProcesso.Consultar(prazo, TipoPesquisa.E)[0];
            LancamentoProcesso processoLancamento = LancamentoProcesso.Instance;

            Lancamento lancamento = new Lancamento();
            lancamento.valor = emprestimo.valor;
            lancamento.lancamentotipo_id = 3;
            lancamento.data = emprestimo.data_emprestimo;
            lancamento.fonte = "Emprestimo";
            lancamento.timeCreated = DateTime.Now;
            lancamento.usuario_id = ClasseAuxiliar.UsuarioLogado.ID;
            processoLancamento.Incluir(lancamento);
            processoLancamento.Confirmar();


            Parcela parcela;
            float valorJuros = emprestimo.valor + (emprestimo.valor * emprestimo.juros / 100);
            float valor = valorJuros / emprestimo.qtde_parcelas;

            //if (valor % 2 == 1)
            //{

            //}

            DateTime dataAtual = DateTime.Now;
            DateTime dataVencimento = DateTime.Now;
            for (int i = 1; i <= emprestimo.qtde_parcelas; i++)
            {
                parcela = new Parcela();
                parcela.emprestimo_id = emprestimo.ID;
                parcela.data_pagamento = null;
                parcela.sequencial = i;
                dataVencimento = dataVencimento.AddDays(prazo.qtde_dias);

                if (dataVencimento.DayOfWeek == DayOfWeek.Saturday)
                    dataVencimento = dataVencimento.AddDays(2);
                else if (dataVencimento.DayOfWeek == DayOfWeek.Monday)
                    dataVencimento = dataVencimento.AddDays(1);


                parcela.data_vencimento = dataVencimento;
                parcela.valor = valor;
                parcela.statusparcela_id = 2;
                parcelaProcesso.Incluir(parcela);
                parcelaProcesso.Confirmar();
            }




        }

        public void Excluir(Emprestimo emprestimo)
        {

            try
            {
                if (emprestimo.ID == 0)
                    throw new EmprestimoNaoExcluidoExcecao();

                List<Emprestimo> resultado = emprestimoRepositorio.Consultar(emprestimo, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new EmprestimoNaoExcluidoExcecao();
                this.emprestimoRepositorio.Excluir(emprestimo);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.emprestimoRepositorio.Excluir(emprestimo);
        }

        public void Alterar(Emprestimo emprestimo)
        {
            this.emprestimoRepositorio.Alterar(emprestimo);
        }

        public List<Emprestimo> Consultar(Emprestimo emprestimo, TipoPesquisa tipoPesquisa)
        {
            List<Emprestimo> emprestimoList = this.emprestimoRepositorio.Consultar(emprestimo, tipoPesquisa);

            return emprestimoList;
        }

        public List<Emprestimo> Consultar()
        {
            List<Emprestimo> emprestimoList = this.emprestimoRepositorio.Consultar();

            return emprestimoList;
        }


        public void Confirmar()
        {
            this.emprestimoRepositorio.Confirmar();
        }

        #endregion
    }
}