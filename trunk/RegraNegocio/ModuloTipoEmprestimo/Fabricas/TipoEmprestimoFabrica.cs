using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloTipoEmprestimo.Repositorios;

namespace RegraNegocio.ModuloTipoEmprestimo.Fabricas
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