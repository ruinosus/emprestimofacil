using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloTipoEmprestimo.Repositorios;
using SiteMVC.ModuloTipoEmprestimo.Processos;
using SiteMVC.ModuloTipoEmprestimo.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloTipoEmprestimo.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloTipoEmprestimo.Processos
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


        #region Métodos da Interface

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

                this.Excluir(tipoEmprestimo);
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