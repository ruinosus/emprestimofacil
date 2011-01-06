using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloEstadoCivilTipo.Repositorios;

namespace SiteMVC.ModuloEstadoCivilTipo.Fabricas
{
    /// <summary>
    /// Classe EstadoCivilTipoFabrica
    /// </summary>
    public class EstadoCivilTipoFabrica
    {
        #region Atributos
        private static IEstadoCivilTipoRepositorio iEstadoCivilTipoRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IEstadoCivilTipoRepositorio.
        /// </summary>
        public static IEstadoCivilTipoRepositorio IEstadoCivilTipoInstance
        {
            get
            {
                iEstadoCivilTipoRepositorioInstance = new EstadoCivilTipoRepositorio();
                return iEstadoCivilTipoRepositorioInstance;
            }

        }
        #endregion
    }
}