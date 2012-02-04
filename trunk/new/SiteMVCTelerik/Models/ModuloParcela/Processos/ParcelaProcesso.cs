
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloParcela.Repositorios;
using SiteMVCTelerik.ModuloParcela.Processos;
using SiteMVCTelerik.ModuloParcela.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloParcela.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
using SiteMVCTelerik.ModuloEmprestimo.Processos;
using SiteMVCTelerik.ModuloPrazoPagamento.Processos;
using SiteMVCTelerik.ModuloLancamento.Processos;
namespace SiteMVCTelerik.ModuloParcela.Processos
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
                if (parcela.id == 0)
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
                //lancamento.timeCreated = DateTime.Now;
                lancamento.usuario_id = ClasseAuxiliar.UsuarioLogado.id;
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
                //lancamento.timeCreated = DateTime.Now;
                lancamento.usuario_id = ClasseAuxiliar.UsuarioLogado.id;
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
                //lancamento.timeCreated = DateTime.Now;
                lancamento.usuario_id = ClasseAuxiliar.UsuarioLogado.id;
                processoLancamento.Incluir(lancamento);
                processoLancamento.Confirmar();
            }
        }

        public void CancelarParcela(Parcela parcela)
        {
            
            LancamentoProcesso processoLancamento = LancamentoProcesso.Instance;
            Lancamento lancamento = new Lancamento();
            lancamento.valor = parcela.valor_pago.Value;
            lancamento.lancamentotipo_id = 9;
            lancamento.data = ClasseAuxiliar.DataSelecionada;
            lancamento.fonte = "parcela";
            //lancamento.timeCreated = DateTime.Now;
            lancamento.usuario_id = ClasseAuxiliar.UsuarioLogado.id;

            parcela.data_pagamento = null;
            parcela.valor_pago = null;
            parcela.statusparcela_id = 2;

            processoLancamento.Incluir(lancamento);
            processoLancamento.Confirmar();
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
            else
            {
                ILancamentoProcesso processoLancamento = LancamentoProcesso.Instance;
                Lancamento lancamento = new Lancamento();
             
                lancamento.valor = parcela.valor_pago.Value;
                lancamento.lancamentotipo_id = 1;
                lancamento.data = parcela.data_pagamento.Value;
                lancamento.fonte = "parcela";
                //lancamento.timeCreated = DateTime.Now;
                lancamento.usuario_id = ClasseAuxiliar.UsuarioLogado.id;
                processoLancamento.Incluir(lancamento);
                processoLancamento.Confirmar();
                parcela.statusparcela_id = 1;
                Parcela p2 = new Parcela();
                p2.statusparcela_id = parcela.statusparcela_id;
                p2.sequencial = parcela.sequencial +1;
                p2.emprestimo_id = parcela.emprestimo_id;
                p2.valor = valorRestante;
                p2.valor_pago = valorRestante;
                p2.data_pagamento = DateTime.Now;
                p2.data_vencimento = DateTime.Now;
                this.Incluir(p2);
                this.Confirmar();
            
            }


        }

        private void AdicionarParcelaExtra(Parcela parcela)
        {

            Parcela p = new Parcela();
            p.emprestimo_id = parcela.emprestimo_id;
            List<Parcela> resultado = this.Consultar(p, TipoPesquisa.E);
            IEmprestimoProcesso processo = EmprestimoProcesso.Instance;

            Emprestimo emp = new Emprestimo();
            emp.id = p.emprestimo_id;

            emp = processo.Consultar(emp, TipoPesquisa.E)[0];

            IPrazoPagamentoProcesso prazoPagamentoProcesso = PrazoPagamentoProcesso.Instance;

            PrazoPagamento prazo = new PrazoPagamento();
            prazo.id = emp.prazospagamento_id;

            prazo = prazoPagamentoProcesso.Consultar(prazo, TipoPesquisa.E)[0];

            p = resultado[resultado.Count - 1];

            if (p != null)
            {
                Parcela par = new Parcela();
                par.emprestimo_id = emp.id;
                par.valor = parcela.valor - parcela.valor_pago.Value;
                par.data_vencimento = p.data_vencimento.AddDays(prazo.qtde_dias);
                par.statusparcela_id = 2;
                par.sequencial = parcela.sequencial;
                par.data_vencimento = parcela.data_vencimento;
                //if (par.data_vencimento.DayOfWeek == DayOfWeek.Saturday)
                //    par.data_vencimento = par.data_vencimento.AddDays(2);
                //else if (par.data_vencimento.DayOfWeek == DayOfWeek.Monday)
                //    par.data_vencimento = par.data_vencimento.AddDays(1);



                //par.timeCreated = DateTime.Now;
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

        public List<Parcela> ConsultarParcelasEmAbertoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            List<Parcela> parcelas = this.Consultar();

            parcelas = (from p in parcelas
                        where p.data_vencimento.Date >= dataInicio.Date && p.data_vencimento.Date <= dataFim.Date && p.statusparcela_id == 2
                                && p.emprestimo.area_id == ClasseAuxiliar.AreaSelecionada.id
                           select p).ToList();

            return parcelas;

        }

        public List<Parcela> ConsultarParcelasPagasPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            List<Parcela> parcelas = this.Consultar();

            if (dataInicio != default(DateTime) && dataFim != default(DateTime))
            {

                parcelas = (from p in parcelas
                            where p.data_pagamento.HasValue && p.data_pagamento.Value.Date >= dataInicio.Date && p.data_vencimento.Date <= dataFim.Date && p.statusparcela_id == 1
                                    && p.emprestimo.area_id == ClasseAuxiliar.AreaSelecionada.id
                            select p).ToList();
            }
            else if (dataInicio != default(DateTime))
            {
                parcelas = (from p in parcelas
                            where p.data_pagamento.HasValue && p.data_pagamento.Value.Date.Equals(dataInicio.Date) && p.statusparcela_id == 1
                                    && p.emprestimo.area_id == ClasseAuxiliar.AreaSelecionada.id
                            select p).ToList();
            }

            return parcelas;
        }   

        #endregion
    }
}