using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloParcela.Repositorios
{
    /// <summary>
    /// Interface IParcelaRepositorio
    /// </summary>
    public interface IParcelaRepositorio
    {
        /// <summary>
        /// Método responsável por incluir uma parcela no sistema.
        /// </summary>
        /// <param name="parcela">Objeto do tipo parcela a ser incluido.</param>
        void Incluir(Parcela parcela);

        /// <summary>
        /// Método responsável por excluir uma parcela do sistema.
        /// </summary>
        /// <param name="parcela">Objeto do tipo parcela a ser excluido.</param>
        void Excluir(Parcela parcela);

        /// <summary>
        /// Método reponsável por alterar uma parcela do sistema.
        /// </summary>
        /// <param name="parcela">Objeto do tipo parcela a ser alterado.</param>
        void Alterar(Parcela parcela);

        /// <summary>
        /// Método responsável por consultar parcelas do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="parcela">Objeto do tipo parcela que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todas as parcelas cadastradas.</returns>
        List<Parcela> Consultar(Parcela parcela, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todas as parcelas do sistema.
        /// </summary>
        /// <returns>Lista contendo todas as parcelas cadastradas.</returns>
        List<Parcela> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}