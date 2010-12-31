LancamentoTipo System;
LancamentoTipo System.Collections.Generic;
LancamentoTipo System.Linq;
LancamentoTipo System.Web;
LancamentoTipo RegraNegocio.ModuloBasico.Constantes;
LancamentoTipo RegraNegocio.ModuloBloqueado.Repositorios;

namespace RegraNegocio.ModuloBloqueado.Fabricas
{
    /// <summary>
    /// Classe BloqueadoFabrica
    /// </summary>
    public class BloqueadoFabrica
    {
        #region Atributos
        private static IBloqueadoRepositorio iBloqueadoRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IBloqueadoRepositorio.
        /// </summary>
        public static IBloqueadoRepositorio IBloqueadoInstance
        {
            get
            {
                iBloqueadoRepositorioInstance = new BloqueadoRepositorio();
                return iBloqueadoRepositorioInstance;
            }

        }
        #endregion
    }
}