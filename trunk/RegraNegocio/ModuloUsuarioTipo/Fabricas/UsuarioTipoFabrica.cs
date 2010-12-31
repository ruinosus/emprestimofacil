using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloUsuarioTipo.Repositorios;

namespace RegraNegocio.ModuloUsuarioTipo.Fabricas
{
    /// <summary>
    /// Classe UsuarioTipoFabrica
    /// </summary>
    public class UsuarioTipoFabrica
    {
        #region Atributos
        private static IUsuarioTipoRepositorio iUsuarioTipoRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IUsuarioTipoRepositorio.
        /// </summary>
        public static IUsuarioTipoRepositorio IUsuarioTipoInstance
        {
            get
            {
                iUsuarioTipoRepositorioInstance = new UsuarioTipoRepositorio();
                return iUsuarioTipoRepositorioInstance;
            }

        }
        #endregion
    }
}