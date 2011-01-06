using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloLancamento.Repositorios;

namespace SiteMVC.ModuloLancamento.Fabricas
{
    /// <summary>
    /// Classe LancamentoFabrica
    /// </summary>
    public class LancamentoFabrica
    {
        #region Atributos
        private static ILancamentoRepositorio iLancamentoRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface ILancamentoRepositorio.
        /// </summary>
        public static ILancamentoRepositorio ILancamentoInstance
        {
            get
            {
                iLancamentoRepositorioInstance = new LancamentoRepositorio();
                return iLancamentoRepositorioInstance;
            }

        }
        #endregion
    }
}