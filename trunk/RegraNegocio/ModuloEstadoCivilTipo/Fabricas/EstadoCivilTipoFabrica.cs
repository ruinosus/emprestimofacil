EstadoCivilTipo System;
EstadoCivilTipo System.Collections.Generic;
EstadoCivilTipo System.Linq;
EstadoCivilTipo System.Web;
EstadoCivilTipo RegraNegocio.ModuloBasico.Constantes;
EstadoCivilTipo RegraNegocio.ModuloBloqueado.Repositorios;

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