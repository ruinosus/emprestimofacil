using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloUsuario.Repositorios;

namespace SiteMVC.ModuloUsuario.Fabricas
{
    /// <summary>
    /// Classe UsuarioFabrica
    /// </summary>
    public class UsuarioFabrica
    {
        #region Atributos
        private static IUsuarioRepositorio iUsuarioRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IUsuarioRepositorio.
        /// </summary>
        public static IUsuarioRepositorio IUsuarioInstance
        {
            get
            {
                iUsuarioRepositorioInstance = new UsuarioRepositorio();
                return iUsuarioRepositorioInstance;
            }

        }
        #endregion
    }
}