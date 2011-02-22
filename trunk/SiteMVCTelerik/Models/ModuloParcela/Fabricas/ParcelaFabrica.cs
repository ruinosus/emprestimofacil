using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloParcela.Repositorios;

namespace SiteMVCTelerik.ModuloParcela.Fabricas
{
    /// <summary>
    /// Classe ParcelaFabrica
    /// </summary>
    public class ParcelaFabrica
    {
        #region Atributos
        private static IParcelaRepositorio iParcelaRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IParcelaRepositorio.
        /// </summary>
        public static IParcelaRepositorio IParcelaInstance
        {
            get
            {
                iParcelaRepositorioInstance = new ParcelaRepositorio();
                return iParcelaRepositorioInstance;
            }

        }
        #endregion
    }
}