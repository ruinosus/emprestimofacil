using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloEscolaridade.Repositorios;

namespace RegraNegocio.ModuloEscolaridade.Fabricas
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