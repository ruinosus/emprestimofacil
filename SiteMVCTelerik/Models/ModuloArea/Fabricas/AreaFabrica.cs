using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloArea.Repositorios;

namespace SiteMVCTelerik.ModuloArea.Fabricas
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