using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloDespesaTipo.Repositorios;

namespace SiteMVC.ModuloDespesaTipo.Fabricas
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