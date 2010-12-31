EstadoCivilTipo System;
EstadoCivilTipo System.Collections.Generic;
EstadoCivilTipo System.Linq;
EstadoCivilTipo System.Web;
EstadoCivilTipo Negocios.ModuloBasico.Constantes;
EstadoCivilTipo Negocios.ModuloBloqueado.Repositorios;

namespace Negocios.ModuloBloqueado.Fabricas
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