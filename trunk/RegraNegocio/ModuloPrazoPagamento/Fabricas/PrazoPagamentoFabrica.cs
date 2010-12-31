using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloPrazoPagamento.Repositorios;

namespace RegraNegocio.ModuloPrazoPagamento.Fabricas
{
    /// <summary>
    /// Classe PrazoPagamentoFabrica
    /// </summary>
    public class PrazoPagamentoFabrica
    {
        #region Atributos
        private static IPrazoPagamentoRepositorio iPrazoPagamentoRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IPrazoPagamentoRepositorio.
        /// </summary>
        public static IPrazoPagamentoRepositorio IPrazoPagamentoInstance
        {
            get
            {
                iPrazoPagamentoRepositorioInstance = new PrazoPagamentoRepositorio();
                return iPrazoPagamentoRepositorioInstance;
            }

        }
        #endregion
    }
}