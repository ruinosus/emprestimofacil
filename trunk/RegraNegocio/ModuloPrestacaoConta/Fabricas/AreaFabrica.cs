using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloPrestacaoConta.Repositorios;

namespace RegraNegocio.ModuloPrestacaoConta.Fabricas
{
    /// <summary>
    /// Classe PrestacaoContaFabrica
    /// </summary>
    public class PrestacaoContaFabrica
    {
        #region Atributos
        private static IPrestacaoContaRepositorio iPrestacaoContaRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IPrestacaoContaRepositorio.
        /// </summary>
        public static IPrestacaoContaRepositorio IPrestacaoContaInstance
        {
            get
            {
                iPrestacaoContaRepositorioInstance = new PrestacaoContaRepositorio();
                return iPrestacaoContaRepositorioInstance;
            }

        }
        #endregion
    }
}