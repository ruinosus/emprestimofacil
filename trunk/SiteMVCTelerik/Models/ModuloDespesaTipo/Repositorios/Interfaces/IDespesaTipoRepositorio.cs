using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloDespesaTipo.Repositorios
{
    /// <summary>
    /// Interface IDespesaTipoRepositorio
    /// </summary>
    public interface IDespesaTipoRepositorio
    {
        /// <summary>
        /// M�todo respons�vel por incluir uma despesaTipo no sistema.
        /// </summary>
        /// <param name="despesaTipo">Objeto do tipo despesaTipo a ser incluido.</param>
        void Incluir(DespesaTipo despesaTipo);

        /// <summary>
        /// M�todo respons�vel por excluir uma despesaTipo do sistema.
        /// </summary>
        /// <param name="despesaTipo">Objeto do tipo despesaTipo a ser excluido.</param>
        void Excluir(DespesaTipo despesaTipo);

        /// <summary>
        /// M�todo repons�vel por alterar uma despesaTipo do sistema.
        /// </summary>
        /// <param name="despesaTipo">Objeto do tipo despesaTipo a ser alterado.</param>
        void Alterar(DespesaTipo despesaTipo);

        /// <summary>
        /// M�todo respons�vel por consultar despesaTipos do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="despesaTipo">Objeto do tipo despesaTipo que ir� ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todas as despesaTipos cadastradas.</returns>
        List<DespesaTipo> Consultar(DespesaTipo despesaTipo, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// M�todo respons�vel por consultar todas as despesaTipos do sistema.
        /// </summary>
        /// <returns>Lista contendo todas as despesaTipos cadastradas.</returns>
        List<DespesaTipo> Consultar();
		
		/// <summary>
        /// M�todo respons�vel por confirmar as altera��es no sistema.
        /// </summary>       
		void Confirmar();
    }
}