using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloEmprestimo.Repositorios;

namespace SiteMVCTelerik.ModuloEmprestimo.Fabricas
{
    /// <summary>
    /// Classe EmprestimoFabrica
    /// </summary>
    public class EmprestimoFabrica
    {
        #region Atributos
        private static IEmprestimoRepositorio iEmprestimoRepositorioInstance;
        #endregion

        #region Propriedades
        /// <summary>
        /// Instancia da interface IEmprestimoRepositorio.
        /// </summary>
        public static IEmprestimoRepositorio IEmprestimoInstance
        {
            get
            {
                iEmprestimoRepositorioInstance = new EmprestimoRepositorio();
                return iEmprestimoRepositorioInstance;
            }

        }
        #endregion
    }
}