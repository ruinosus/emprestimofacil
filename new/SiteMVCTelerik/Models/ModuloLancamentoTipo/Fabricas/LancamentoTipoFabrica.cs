using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloLancamentoTipo.Repositorios;

namespace SiteMVCTelerik.ModuloLancamentoTipo.Fabricas
{
    /// <summary>
    /// Classe LancamentoTipoFabrica
    /// </summary>
    public class LancamentoTipoFabrica
    {
        #region Atributos
        private static ILancamentoTipoRepositorio iLancamentoTipoRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface ILancamentoTipoRepositorio.
        /// </summary>
        public static ILancamentoTipoRepositorio ILancamentoTipoInstance
        {
            get
            {
                iLancamentoTipoRepositorioInstance = new LancamentoTipoRepositorio();
                return iLancamentoTipoRepositorioInstance;
            }

        }
        #endregion
    }
}