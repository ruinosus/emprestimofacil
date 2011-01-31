using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloUsuarioArea.Repositorios;

namespace SiteMVC.ModuloUsuarioArea.Fabricas
{
    /// <summary>
    /// Classe UsuarioAreaFabrica
    /// </summary>
    public class UsuarioAreaFabrica
    {
        #region Atributos
        private static IUsuarioAreaRepositorio iUsuarioAreaRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IUsuarioAreaRepositorio.
        /// </summary>
        public static IUsuarioAreaRepositorio IUsuarioAreaInstance
        {
            get
            {
                iUsuarioAreaRepositorioInstance = new UsuarioAreaRepositorio();
                return iUsuarioAreaRepositorioInstance;
            }

        }
        #endregion
    }
}