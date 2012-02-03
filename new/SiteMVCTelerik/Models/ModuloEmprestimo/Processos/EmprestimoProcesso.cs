using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloEmprestimo.Repositorios;
using SiteMVCTelerik.ModuloEmprestimo.Processos;
using SiteMVCTelerik.ModuloEmprestimo.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloEmprestimo.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
using SiteMVCTelerik.ModuloParcela.Processos;
using SiteMVCTelerik.ModuloPrazoPagamento.Processos;
using SiteMVCTelerik.ModuloLancamento.Processos;

namespace SiteMVCTelerik.ModuloEmprestimo.Processos
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

        public void Incluir(Emprestimo emprestimo, List<DayOfWeek> diasUteis)
        {

            this.emprestimoRepositorio.Incluir(emprestimo);
            this.Confirmar();
            IParcelaProcesso parcelaProcesso = ParcelaProcesso.Instance;
            IPrazoPagamentoProcesso prazoPagamentoProcesso = PrazoPagamentoProcesso.Instance;

            PrazoPagamento prazo = new PrazoPagamento();
            prazo.id = emprestimo.prazospagamento_id;

            prazo = prazoPagamentoProcesso.Consultar(prazo, TipoPesquisa.E)[0];
            LancamentoProcesso processoLancamento = LancamentoProcesso.Instance;

            Lancamento lancamento = new Lancamento();
            lancamento.valor = emprestimo.valor;
            lancamento.lancamentotipo_id = 3;
            lancamento.data = emprestimo.data_emprestimo;
            lancamento.fonte = "Emprestimo";
            lancamento.timeCreated = DateTime.Now;
            lancamento.usuario_id = ClasseAuxiliar.UsuarioLogado.id;
            lancamento.timeCreated = DateTime.Now;
            lancamento.timeUpdated= DateTime.Now;
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
                parcela.emprestimo_id = emprestimo.id;
                parcela.data_pagamento = null;
                parcela.sequencial = i;
                parcela.timeCreated = DateTime.Now;
                parcela.timeUpdated = DateTime.Now;
                dataVencimento = dataVencimento.AddDays(prazo.qtde_dias);

                //if (dataVencimento.DayOfWeek == System.DayOfWeek.Monday)
                //    dataVencimento = dataVencimento.AddDays(1);
                dataVencimento = VerificarProximaData(dataVencimento, diasUteis);

                parcela.data_vencimento = dataVencimento;
                parcela.valor = valor;
                parcela.statusparcela_id = 2;
                parcelaProcesso.Incluir(parcela);
                parcelaProcesso.Confirmar();
            }




        }

        private DateTime VerificarProximaData(DateTime dataAtual, List<DayOfWeek> diasUteis)
        {
            DateTime dataNova = dataAtual;
            bool valida = false;
            foreach (DayOfWeek day in diasUteis)
            {
                if (day == dataNova.DayOfWeek)
                    valida = true;
            }
            if(!valida)
            {
                dataNova = dataNova.AddDays(1);
                return VerificarProximaData(dataNova, diasUteis);

            }
            
            return dataNova;
        }

        public void Excluir(Emprestimo emprestimo)
        {
            try
            {
                if (emprestimo.id == 0)
                    throw new EmprestimoNaoExcluidoExcecao();


                IParcelaProcesso parcelaProcesso = ParcelaProcesso.Instance;
                ILancamentoProcesso lancamentoprocesso = LancamentoProcesso.Instance;
                Parcela parcela = new Parcela();
                parcela.emprestimo_id = emprestimo.id;
                List<Parcela> parcelas = parcelaProcesso.Consultar(parcela, TipoPesquisa.E);

                for (int i = 0; i < parcelas.Count; i++)
                {
                    parcelaProcesso.Excluir(parcelas[i]);
                    parcelaProcesso.Confirmar();
                }

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

        public List<Emprestimo> ConsultarEmprestimosPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            Emprestimo emp = new Emprestimo();
            emp.area_id = ClasseAuxiliar.AreaSelecionada.id;
            List<Emprestimo> emprestimos = this.Consultar(emp,TipoPesquisa.E);

            emprestimos =( from e in emprestimos
                            where e.data_emprestimo >= dataInicio && e.data_emprestimo <= dataFim
                            select e).ToList(); 

            return emprestimos;

        }

        #endregion
    }
}