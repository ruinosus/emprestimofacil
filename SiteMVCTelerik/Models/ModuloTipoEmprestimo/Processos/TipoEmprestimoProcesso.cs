using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloTipoEmprestimo.Repositorios;
using SiteMVCTelerik.ModuloTipoEmprestimo.Processos;
using SiteMVCTelerik.ModuloTipoEmprestimo.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloTipoEmprestimo.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloTipoEmprestimo.Processos
{
    /// <summary>
    /// Classe TipoEmprestimoProcesso
    /// </summary>
    public class TipoEmprestimoProcesso : Singleton<TipoEmprestimoProcesso>, ITipoEmprestimoProcesso
    {
        #region Atributos
        private ITipoEmprestimoRepositorio tipoEmprestimoRepositorio = null;
        #endregion

        #region Construtor
        public TipoEmprestimoProcesso()
        {
            tipoEmprestimoRepositorio = TipoEmprestimoFabrica.ITipoEmprestimoInstance;
        }

        #endregion


        #region M�todos da Interface

        public void Incluir(TipoEmprestimo tipoEmprestimo)
        {
            this.tipoEmprestimoRepositorio.Incluir(tipoEmprestimo);

        }

        public void Excluir(TipoEmprestimo tipoEmprestimo)
        {

            try
            {
                if (tipoEmprestimo.ID == 0)
                    throw new TipoEmprestimoNaoExcluidoExcecao();

                List<TipoEmprestimo> resultado = tipoEmprestimoRepositorio.Consultar(tipoEmprestimo, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new TipoEmprestimoNaoExcluidoExcecao();

                this.tipoEmprestimoRepositorio.Excluir(tipoEmprestimo);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.tipoEmprestimoRepositorio.Excluir(tipoEmprestimo);
        }

        public void Alterar(TipoEmprestimo tipoEmprestimo)
        {
            this.tipoEmprestimoRepositorio.Alterar(tipoEmprestimo);
        }

        public List<TipoEmprestimo> Consultar(TipoEmprestimo tipoEmprestimo, TipoPesquisa tipoPesquisa)
        {
            List<TipoEmprestimo> tipoEmprestimoList = this.tipoEmprestimoRepositorio.Consultar(tipoEmprestimo,tipoPesquisa);           

            return tipoEmprestimoList;
        }

        public List<TipoEmprestimo> Consultar()
        {
            List<TipoEmprestimo> tipoEmprestimoList = this.tipoEmprestimoRepositorio.Consultar();

            return tipoEmprestimoList;
        }

     
        public void Confirmar()
        {
            this.tipoEmprestimoRepositorio.Confirmar();
        }

        #endregion
    }
}