using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloStatusParcela.Repositorios;

namespace SiteMVCTelerik.ModuloStatusParcela.Fabricas
{
    /// <summary>
    /// Classe StatusParcelaFabrica
    /// </summary>
    public class StatusParcelaFabrica
    {
        #region Atributos
        private static IStatusParcelaRepositorio iStatusParcelaRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IStatusParcelaRepositorio.
        /// </summary>
        public static IStatusParcelaRepositorio IStatusParcelaInstance
        {
            get
            {
                iStatusParcelaRepositorioInstance = new StatusParcelaRepositorio();
                return iStatusParcelaRepositorioInstance;
            }

        }
        #endregion
    }
}