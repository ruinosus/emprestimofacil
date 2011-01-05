using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloUsuarioTipo.Repositorios;

namespace SiteMVC.ModuloUsuarioTipo.Fabricas
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