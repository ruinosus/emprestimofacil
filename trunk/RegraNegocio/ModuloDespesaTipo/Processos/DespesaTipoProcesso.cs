
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Singleton;
using RegraNegocio.ModuloDespesaTipo.Repositorios;
using RegraNegocio.ModuloDespesaTipo.Processos;
using RegraNegocio.ModuloDespesaTipo.Fabricas;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloDespesaTipo.Excecoes;
using RegraNegocio.ModuloBasico.VOs;
namespace RegraNegocio.ModuloDespesaTipo.Processos
{
    /// <summary>
    /// Classe DespesaTipoProcesso
    /// </summary>
    public class DespesaTipoProcesso : Singleton<DespesaTipoProcesso>, IDespesaTipoProcesso
    {
        #region Atributos
        private IDespesaTipoRepositorio despesaTipoRepositorio = null;
        #endregion

        #region Construtor
        public DespesaTipoProcesso()
        {
            despesaTipoRepositorio = DespesaTipoFabrica.IDespesaTipoInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(DespesaTipo despesaTipo)
        {
            this.despesaTipoRepositorio.Incluir(despesaTipo);

        }

        public void Excluir(DespesaTipo despesaTipo)
        {
            try
            {
                if (despesaTipo.ID == 0)
                    throw new DespesaTipoNaoExcluidaExcecao();

                List<DespesaTipo> resultado = despesaTipoRepositorio.Consultar(despesaTipo, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new DespesaTipoNaoExcluidaExcecao();

                this.Excluir(despesaTipo);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.despesaTipoRepositorio.Excluir(despesaTipo);
        }

        public void Alterar(DespesaTipo despesaTipo)
        {
            this.despesaTipoRepositorio.Alterar(despesaTipo);
        }

        public List<DespesaTipo> Consultar(DespesaTipo despesaTipo, TipoPesquisa tipoPesquisa)
        {
            List<DespesaTipo> despesaTipoList = this.despesaTipoRepositorio.Consultar(despesaTipo,tipoPesquisa);           

            return despesaTipoList;
        }

        public List<DespesaTipo> Consultar()
        {
            List<DespesaTipo> despesaTipoList = this.despesaTipoRepositorio.Consultar();

            return despesaTipoList;
        }

        public void Confirmar()
        {
            this.despesaTipoRepositorio.Confirmar();
        }

        #endregion
    }
}