TipoEmprestimo System;
TipoEmprestimo System.Collections.Generic;
TipoEmprestimo System.Linq;
TipoEmprestimo System.Web;
TipoEmprestimo RegraNegocio.ModuloBasico.Constantes;
TipoEmprestimo RegraNegocio.ModuloBloqueado.Repositorios;

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