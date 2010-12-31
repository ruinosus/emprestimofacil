using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloParcela.Repositorios;

namespace Negocios.ModuloParcela.Fabricas
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