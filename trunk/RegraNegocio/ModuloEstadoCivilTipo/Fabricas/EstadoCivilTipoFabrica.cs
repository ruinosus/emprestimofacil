using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloEstadoCivilTipo.Repositorios;

namespace RegraNegocio.ModuloEstadoCivilTipo.Fabricas
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