using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloOrgaoExpedidorNome.Repositorios;

namespace SiteMVC.ModuloOrgaoExpedidorNome.Fabricas
{
    /// <summary>
    /// Classe OrgaoExpedidorNomeFabrica
    /// </summary>
    public class OrgaoExpedidorNomeFabrica
    {
        #region Atributos
        private static IOrgaoExpedidorNomeRepositorio iOrgaoExpedidorNomeRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IOrgaoExpedidorNomeRepositorio.
        /// </summary>
        public static IOrgaoExpedidorNomeRepositorio IOrgaoExpedidorNomeInstance
        {
            get
            {
                iOrgaoExpedidorNomeRepositorioInstance = new OrgaoExpedidorNomeRepositorio();
                return iOrgaoExpedidorNomeRepositorioInstance;
            }

        }
        #endregion
    }
}