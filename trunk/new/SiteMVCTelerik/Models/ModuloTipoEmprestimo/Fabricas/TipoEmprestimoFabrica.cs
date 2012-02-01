using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloTipoEmprestimo.Repositorios;

namespace SiteMVCTelerik.ModuloTipoEmprestimo.Fabricas
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