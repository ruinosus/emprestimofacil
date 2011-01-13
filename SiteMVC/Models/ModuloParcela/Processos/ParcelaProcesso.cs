
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloParcela.Repositorios;
using SiteMVC.ModuloParcela.Processos;
using SiteMVC.ModuloParcela.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloParcela.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloEmprestimo.Processos;
using SiteMVC.ModuloPrazoPagamento.Processos;
using SiteMVC.ModuloLancamento.Processos;
namespace SiteMVC.ModuloParcela.Processos
{
    /// <summary>
    /// Classe ParcelaProcesso
    /// </summary>
    public class ParcelaProcesso : Singleton<ParcelaProcesso>, IParcelaProcesso
    {
        #region Atributos
        private IParcelaRepositorio parcelaRepositorio = null;
        #endregion

        #region Construtor
        public ParcelaProcesso()
        {
            parcelaRepositorio = ParcelaFabrica.IParcelaInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(Parcela parcela)
        {
            this.parcelaRepositorio.Incluir(parcela);

        }

        public void Excluir(Parcela parcela)
        {
            try
            {
                if (parcela.ID == 0)
                    throw new ParcelaNaoExcluidaExcecao();

                List<Parcela> resultado = parcelaRepositorio.Consultar(parcela, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new ParcelaNaoExcluidaExcecao();
                this.parcelaRepositorio.Excluir(parcela);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.parcelaRepositorio.Excluir(parcela);
        }

        public void Alterar(Parcela parcela)
        {
            parcela.data_pagamento = DateTime.Now;
            parcela.statusparcela_id = 1;
            LancamentoProcesso processoLancamento = LancamentoProcesso.Instance;

          

            if (parcela.valor_pago.Value > parcela.valor)
            {
                float valorRestante = parcela.valor_pago.Value - parcela.valor;
                parcela.valor_pago = parcela.valor;
                this.parcelaRepositorio.Alterar(parcela);
                Lancamento lancamento = new Lancamento();
                lancamento.valor = parcela.valor_pago.Value;
                lancamento.lancamentotipo_id = 1;
                lancamento.data = parcela.data_pagamento.Value;
                lancamento.fonte = "parcela";
                lancamento.timeCreated = DateTime.Now;
                lancamento.usuario_id = ClasseAuxiliar.UsuarioLogado.ID;
                processoLancamento.Incluir(lancamento);
                processoLancamento.Confirmar();
                this.PagarProximaParcela(parcela, valorRestante);
            }
            else if (parcela.valor_pago.Value < parcela.valor)
            {
                this.parcelaRepositorio.Alterar(parcela);
                Lancamento lancamento = new Lancamento();
                lancamento.valor = parcela.valor_pago.Value;
                lancamento.lancamentotipo_id = 1;
                lancamento.data = parcela.data_pagamento.Value;
                lancamento.fonte = "parcela";
                lancamento.timeCreated = DateTime.Now;
                lancamento.usuario_id = ClasseAuxiliar.UsuarioLogado.ID;
                processoLancamento.Incluir(lancamento);
                processoLancamento.Confirmar();
                this.AdicionarParcelaExtra(parcela);

            }
            else
            {
                this.parcelaRepositorio.Alterar(parcela);
                Lancamento lancamento = new Lancamento();
                lancamento.valor = parcela.valor_pago.Value;
                lancamento.lancamentotipo_id = 1;
                lancamento.data = parcela.data_pagamento.Value;
                lancamento.fonte = "parcela";
                lancamento.timeCreated = DateTime.Now;
                lancamento.usuario_id = ClasseAuxiliar.UsuarioLogado.ID;
                processoLancamento.Incluir(lancamento);
                processoLancamento.Confirmar();
            }
        }

        private void PagarProximaParcela(Parcela parcela, float valorRestante)
        {
            Parcela p = new Parcela();
            p.emprestimo_id = parcela.emprestimo_id;
            List<Parcela> resultado = this.Consultar(p, TipoPesquisa.E);

            p = this.verificarProximaParcela(resultado);

            if (p != null)
            {
                p.data_pagamento = DateTime.Now;
                p.statusparcela_id = 2;
                p.valor_pago = valorRestante;
                if (valorRestante > parcela.valor)
                {
                    //valorRestante = parcela.valor_pago.Value - parcela.valor;
                    //p.valor_pago = parcela.valor;
                    this.Alterar(p);
                    //this.PagarProximaParcela(p, valorRestante);
                }
                else if (valorRestante < parcela.valor)
                {
                    //p.valor_pago = valorRestante;
                    this.Alterar(p);
                   // this.AdicionarParcelaExtra(p);
                }
                else
                {
                    //p.valor_pago = valorRestante;
                    this.Alterar(p);
                }
            }


        }

        private void AdicionarParcelaExtra(Parcela parcela)
        {

            Parcela p = new Parcela();
            p.emprestimo_id = parcela.emprestimo_id;
            List<Parcela> resultado = this.Consultar(p, TipoPesquisa.E);
            IEmprestimoProcesso processo = EmprestimoProcesso.Instance;

            Emprestimo emp = new Emprestimo();
            emp.ID = p.emprestimo_id;

            emp = processo.Consultar(emp, TipoPesquisa.E)[0];

            IPrazoPagamentoProcesso prazoPagamentoProcesso = PrazoPagamentoProcesso.Instance;

            PrazoPagamento prazo = new PrazoPagamento();
            prazo.ID = emp.prazospagamento_id;

            prazo = prazoPagamentoProcesso.Consultar(prazo, TipoPesquisa.E)[0];

            p = resultado[resultado.Count - 1];

            if (p != null)
            {
                Parcela par = new Parcela();
                par.emprestimo_id = emp.ID;
                par.valor = parcela.valor - parcela.valor_pago.Value;
                par.data_vencimento = p.data_vencimento.AddDays(prazo.qtde_dias);
                par.statusparcela_id = 2;
                if (par.data_vencimento.DayOfWeek == DayOfWeek.Saturday)
                    par.data_vencimento = par.data_vencimento.AddDays(2);
                else if (par.data_vencimento.DayOfWeek == DayOfWeek.Monday)
                    par.data_vencimento = par.data_vencimento.AddDays(1);



                par.timeCreated = DateTime.Now;
                this.parcelaRepositorio.Incluir(par);
            }


        }

        private Parcela verificarProximaParcela(List<Parcela> resultado)
        {


            for (int i = 0; i < resultado.Count; i++)
            {
                if (resultado[i].statusparcela_id == 2)
                {
                    return resultado[i];
                }

            }


            return null;
        }

        public List<Parcela> Consultar(Parcela parcela, TipoPesquisa tipoPesquisa)
        {
            List<Parcela> parcelaList = this.parcelaRepositorio.Consultar(parcela, tipoPesquisa);

            return parcelaList;
        }

        public List<Parcela> Consultar()
        {
            List<Parcela> parcelaList = this.parcelaRepositorio.Consultar();

            return parcelaList;
        }

        public void Confirmar()
        {
            this.parcelaRepositorio.Confirmar();
        }

        #endregion
    }
}