using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloLancamento.Repositorios;

namespace SiteMVCTelerik.ModuloLancamento.Fabricas
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