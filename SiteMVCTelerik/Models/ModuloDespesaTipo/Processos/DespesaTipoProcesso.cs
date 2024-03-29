
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloDespesaTipo.Repositorios;
using SiteMVCTelerik.ModuloDespesaTipo.Processos;
using SiteMVCTelerik.ModuloDespesaTipo.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloDespesaTipo.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
namespace SiteMVCTelerik.ModuloDespesaTipo.Processos
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


        #region M�todos da Interface

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

                this.despesaTipoRepositorio.Excluir(despesaTipo);
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