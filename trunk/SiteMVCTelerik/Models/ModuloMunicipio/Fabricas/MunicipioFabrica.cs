using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloMunicipio.Repositorios;

namespace SiteMVCTelerik.ModuloMunicipio.Fabricas
{
    /// <summary>
    /// Classe MunicipioFabrica
    /// </summary>
    public class MunicipioFabrica
    {
        #region Atributos
        private static IMunicipioRepositorio iMunicipioRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IMunicipioRepositorio.
        /// </summary>
        public static IMunicipioRepositorio IMunicipioInstance
        {
            get
            {
                iMunicipioRepositorioInstance = new MunicipioRepositorio();
                return iMunicipioRepositorioInstance;
            }

        }
        #endregion
    }
}