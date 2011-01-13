using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.ModuloBasico;
using SiteMVC.ModuloBasico.Enums;

namespace SiteMVC.ModuloArea.Repositorios
{
    /// <summary>
    /// Interface IAreaRepositorio
    /// </summary>
    public interface IAreaRepositorio
    {
        /// <summary>
        /// Método responsável por incluir uma area no sistema.
        /// </summary>
        /// <param name="area">Objeto do tipo area a ser incluido.</param>
        void Incluir(Area area);

        /// <summary>
        /// Método responsável por excluir uma area do sistema.
        /// </summary>
        /// <param name="area">Objeto do tipo area a ser excluido.</param>
        void Excluir(Area area);

        /// <summary>
        /// Método reponsável por alterar uma area do sistema.
        /// </summary>
        /// <param name="area">Objeto do tipo area a ser alterado.</param>
        void Alterar(Area area);

        /// <summary>
        /// Método responsável por consultar areas do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="area">Objeto do tipo area que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todas as areas cadastradas.</returns>
        List<Area> Consultar(Area area, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todas as areas do sistema.
        /// </summary>
        /// <returns>Lista contendo todas as areas cadastradas.</returns>
        List<Area> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}