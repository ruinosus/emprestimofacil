using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloTipoEmprestimo.Repositorios;

namespace SiteMVC.ModuloTipoEmprestimo.Fabricas
{
    /// <summary>
    /// Classe TipoEmprestimoFabrica
    /// </summary>
    public class TipoEmprestimoFabrica
    {
        #region Atributos
        private static ITipoEmprestimoRepositorio iTipoEmprestimoRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface ITipoEmprestimoRepositorio.
        /// </summary>
        public static ITipoEmprestimoRepositorio ITipoEmprestimoInstance
        {
            get
            {
                iTipoEmprestimoRepositorioInstance = new TipoEmprestimoRepositorio();
                return iTipoEmprestimoRepositorioInstance;
            }

        }
        #endregion
    }
}