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
        /// M�todo respons�vel por incluir uma area no sistema.
        /// </summary>
        /// <param name="area">Objeto do tipo area a ser incluido.</param>
        void Incluir(Area area);

        /// <summary>
        /// M�todo respons�vel por excluir uma area do sistema.
        /// </summary>
        /// <param name="area">Objeto do tipo area a ser excluido.</param>
        void Excluir(Area area);

        /// <summary>
        /// M�todo repons�vel por alterar uma area do sistema.
        /// </summary>
        /// <param name="area">Objeto do tipo area a ser alterado.</param>
        void Alterar(Area area);

        /// <summary>
        /// M�todo respons�vel por consultar areas do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="area">Objeto do tipo area que ir� ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todas as areas cadastradas.</returns>
        List<Area> Consultar(Area area, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// M�todo respons�vel por consultar todas as areas do sistema.
        /// </summary>
        /// <returns>Lista contendo todas as areas cadastradas.</returns>
        List<Area> Consultar();
		
		/// <summary>
        /// M�todo respons�vel por confirmar as altera��es no sistema.
        /// </summary>       
		void Confirmar();
    }
}