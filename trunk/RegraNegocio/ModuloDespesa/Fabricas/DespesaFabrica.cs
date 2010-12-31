using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloDespesa.Repositorios;

namespace Negocios.ModuloDespesa.Fabricas
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