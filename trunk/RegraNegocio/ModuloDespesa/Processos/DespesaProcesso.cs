
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Singleton;
using RegraNegocio.ModuloDespesa.Repositorios;
using RegraNegocio.ModuloDespesa.Processos;
using RegraNegocio.ModuloDespesa.Fabricas;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloDespesa.Excecoes;
using RegraNegocio.ModuloBasico.VOs;
namespace RegraNegocio.ModuloDespesa.Processos
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

                this.Excluir(Despesa);
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