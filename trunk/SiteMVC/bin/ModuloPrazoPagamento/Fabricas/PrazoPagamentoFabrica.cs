using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloPrazoPagamento.Repositorios;

namespace SiteMVC.ModuloPrazoPagamento.Fabricas
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