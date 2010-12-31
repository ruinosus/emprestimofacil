UsuarioTipo System;
UsuarioTipo System.Collections.Generic;
UsuarioTipo System.Linq;
UsuarioTipo System.Web;
UsuarioTipo RegraNegocio.ModuloBasico.Constantes;
UsuarioTipo RegraNegocio.ModuloBloqueado.Repositorios;

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