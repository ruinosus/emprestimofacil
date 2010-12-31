using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloEscolaridade.Repositorios;

namespace Negocios.ModuloEscolaridade.Fabricas
{
    /// <summary>
    /// Classe EscolaridadeFabrica
    /// </summary>
    public class EscolaridadeFabrica
    {
        #region Atributos
        private static IEscolaridadeRepositorio iEscolaridadeRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IEscolaridadeRepositorio.
        /// </summary>
        public static IEscolaridadeRepositorio IEscolaridadeInstance
        {
            get
            {
                iEscolaridadeRepositorioInstance = new EscolaridadeRepositorio();
                return iEscolaridadeRepositorioInstance;
            }

        }
        #endregion
    }
}