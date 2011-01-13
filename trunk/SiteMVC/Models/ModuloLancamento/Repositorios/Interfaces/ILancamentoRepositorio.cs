using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloLancamento.Repositorios
{
    /// <summary>
    /// Summary description for ILancamentoRepositorio
    /// </summary>
    public interface ILancamentoRepositorio
    {
        /// <summary>
        /// Método responsável por incluir um lancamento no sistema.
        /// </summary>
        /// <param name="lancamento">Objeto do tipo lancamento a ser incluido.</param>
        void Incluir(Lancamento lancamento);

        /// <summary>
        /// Método responsável por excluir um lancamento do sistema.
        /// </summary>
        /// <param name="lancamento">Objeto do tipo lancamento a ser excluido.</param>
        void Excluir(Lancamento lancamento);

        /// <summary>
        /// Método reponsável por alterar um lancamento do sistema.
        /// </summary>
        /// <param name="lancamento">Objeto do tipo lancamento a ser alterado.</param>
        void Alterar(Lancamento lancamento);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="lancamento">Objeto do tipo lancamento que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<Lancamento> Consultar(Lancamento lancamento, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os lancamentos cadastrados.</returns>
        List<Lancamento> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}