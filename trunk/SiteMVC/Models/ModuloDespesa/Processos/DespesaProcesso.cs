
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloDespesa.Repositorios;
using SiteMVC.ModuloDespesa.Processos;
using SiteMVC.ModuloDespesa.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloDespesa.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloLancamento.Processos;
namespace SiteMVC.ModuloDespesa.Processos
{
    /// <summary>
    /// Classe DespesaProcesso
    /// </summary>
    public class DespesaProcesso : Singleton<DespesaProcesso>, IDespesaProcesso
    {
        #region Atributos
        private IDespesaRepositorio DespesaRepositorio = null;
        #endregion

        #region Construtor
        public DespesaProcesso()
        {
            DespesaRepositorio = DespesaFabrica.IDespesaInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(Despesa Despesa)
        {

            ILancamentoProcesso processoLancamento = LancamentoProcesso.Instance;
            Lancamento lancamento = new Lancamento();
            lancamento.valor = Despesa.valor;
            lancamento.lancamentotipo_id = 2;
            lancamento.data = Despesa.data;
            lancamento.fonte = "Despesa";
            lancamento.timeCreated = DateTime.Now;
            lancamento.usuario_id = Despesa.usuario_id;
            processoLancamento.Incluir(lancamento);
            processoLancamento.Confirmar();


            this.DespesaRepositorio.Incluir(Despesa);

        }

        public void Excluir(Despesa Despesa)
        {
            try
            {
                if (Despesa.ID == 0)
                    throw new DespesaNaoExcluidaExcecao();

                List<Despesa> resultado = DespesaRepositorio.Consultar(Despesa, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new DespesaNaoExcluidaExcecao();

                this.DespesaRepositorio.Excluir(Despesa);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.DespesaRepositorio.Excluir(Despesa);
        }

        public void Alterar(Despesa Despesa)
        {
            this.DespesaRepositorio.Alterar(Despesa);
        }

        public List<Despesa> Consultar(Despesa Despesa, TipoPesquisa tipoPesquisa)
        {
            List<Despesa> DespesaList = this.DespesaRepositorio.Consultar(Despesa,tipoPesquisa);           

            return DespesaList;
        }

        public List<Despesa> Consultar()
        {
            List<Despesa> DespesaList = this.DespesaRepositorio.Consultar();

            return DespesaList;
        }

        public void Confirmar()
        {
            this.DespesaRepositorio.Confirmar();
        }

        #endregion
    }
}