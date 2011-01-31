using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloDespesa.Repositorios;

namespace SiteMVC.ModuloDespesa.Fabricas
{
    /// <summary>
    /// Classe DespesaFabrica
    /// </summary>
    public class DespesaFabrica
    {
        #region Atributos
        private static IDespesaRepositorio iDespesaRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IDespesaRepositorio.
        /// </summary>
        public static IDespesaRepositorio IDespesaInstance
        {
            get
            {
                iDespesaRepositorioInstance = new DespesaRepositorio();
                return iDespesaRepositorioInstance;
            }

        }
        #endregion
    }
}