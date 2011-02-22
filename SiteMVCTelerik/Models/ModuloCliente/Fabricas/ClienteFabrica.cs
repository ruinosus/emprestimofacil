using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloCliente.Repositorios;

namespace SiteMVCTelerik.ModuloCliente.Fabricas
{
    /// <summary>
    /// Classe ClienteFabrica
    /// </summary>
    public class ClienteFabrica
    {
        #region Atributos
        private static IClienteRepositorio iClienteRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IClienteRepositorio.
        /// </summary>
        public static IClienteRepositorio IClienteInstance
        {
            get
            {
                iClienteRepositorioInstance = new ClienteRepositorio();
                return iClienteRepositorioInstance;
            }

        }
        #endregion
    }
}