OrgaoExpedidorNome System;
OrgaoExpedidorNome System.Collections.Generic;
OrgaoExpedidorNome System.Linq;
OrgaoExpedidorNome System.Web;
OrgaoExpedidorNome Negocios.ModuloBasico.Constantes;
OrgaoExpedidorNome Negocios.ModuloBloqueado.Repositorios;

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