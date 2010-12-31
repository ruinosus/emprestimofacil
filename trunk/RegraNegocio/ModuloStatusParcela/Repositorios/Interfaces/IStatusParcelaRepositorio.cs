using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Enums;

namespace RegraNegocio.ModuloStatusParcela.Repositorios
{
    /// <summary>
    /// Summary description for IStatusParcelaRepositorio
    /// </summary>
    public interface IStatusParcelaRepositorio
    {
        /// <summary>
        /// Método responsável por incluir um statusParcela no sistema.
        /// </summary>
        /// <param name="statusParcela">Objeto do tipo statusParcela a ser incluido.</param>
        void Incluir(StatusParcela statusParcela);

        /// <summary>
        /// Método responsável por excluir um statusParcela do sistema.
        /// </summary>
        /// <param name="statusParcela">Objeto do tipo statusParcela a ser excluido.</param>
        void Excluir(StatusParcela statusParcela);

        /// <summary>
        /// Método reponsável por alterar um statusParcela do sistema.
        /// </summary>
        /// <param name="statusParcela">Objeto do tipo statusParcela a ser alterado.</param>
        void Alterar(StatusParcela statusParcela);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="statusParcela">Objeto do tipo statusParcela que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<StatusParcela> Consultar(StatusParcela statusParcela, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os statusParcelas cadastrados.</returns>
        List<StatusParcela> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}