using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloArea.Repositorios;

namespace SiteMVC.ModuloArea.Fabricas
{
    /// <summary>
    /// Classe AreaFabrica
    /// </summary>
    public class AreaFabrica
    {
        #region Atributos
        private static IAreaRepositorio iAreaRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IAreaRepositorio.
        /// </summary>
        public static IAreaRepositorio IAreaInstance
        {
            get
            {
                iAreaRepositorioInstance = new AreaRepositorio();
                return iAreaRepositorioInstance;
            }

        }
        #endregion
    }
}