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
        /// Método responsável por incluir uma despesaTipo no sistema.
        /// </summary>
        /// <param name="despesaTipo">Objeto do tipo despesaTipo a ser incluido.</param>
        void Incluir(DespesaTipo despesaTipo);

        /// <summary>
        /// Método responsável por excluir uma despesaTipo do sistema.
        /// </summary>
        /// <param name="despesaTipo">Objeto do tipo despesaTipo a ser excluido.</param>
        void Excluir(DespesaTipo despesaTipo);

        /// <summary>
        /// Método reponsável por alterar uma despesaTipo do sistema.
        /// </summary>
        /// <param name="despesaTipo">Objeto do tipo despesaTipo a ser alterado.</param>
        void Alterar(DespesaTipo despesaTipo);

        /// <summary>
        /// Método responsável por consultar despesaTipos do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="despesaTipo">Objeto do tipo despesaTipo que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todas as despesaTipos cadastradas.</returns>
        List<DespesaTipo> Consultar(DespesaTipo despesaTipo, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todas as despesaTipos do sistema.
        /// </summary>
        /// <returns>Lista contendo todas as despesaTipos cadastradas.</returns>
        List<DespesaTipo> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}