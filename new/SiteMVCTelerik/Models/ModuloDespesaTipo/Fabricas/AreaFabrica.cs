using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloDespesaTipo.Repositorios;

namespace SiteMVCTelerik.ModuloDespesaTipo.Fabricas
{
    /// <summary>
    /// Classe DespesaTipoFabrica
    /// </summary>
    public class DespesaTipoFabrica
    {
        #region Atributos
        private static IDespesaTipoRepositorio iDespesaTipoRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IDespesaTipoRepositorio.
        /// </summary>
        public static IDespesaTipoRepositorio IDespesaTipoInstance
        {
            get
            {
                iDespesaTipoRepositorioInstance = new DespesaTipoRepositorio();
                return iDespesaTipoRepositorioInstance;
            }

        }
        #endregion
    }
}