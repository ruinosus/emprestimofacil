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
        /// M�todo respons�vel por incluir um statusParcela no sistema.
        /// </summary>
        /// <param name="statusParcela">Objeto do tipo statusParcela a ser incluido.</param>
        void Incluir(StatusParcela statusParcela);

        /// <summary>
        /// M�todo respons�vel por excluir um statusParcela do sistema.
        /// </summary>
        /// <param name="statusParcela">Objeto do tipo statusParcela a ser excluido.</param>
        void Excluir(StatusParcela statusParcela);

        /// <summary>
        /// M�todo repons�vel por alterar um statusParcela do sistema.
        /// </summary>
        /// <param name="statusParcela">Objeto do tipo statusParcela a ser alterado.</param>
        void Alterar(StatusParcela statusParcela);

        /// <summary>
        /// M�todo respons�vel por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="statusParcela">Objeto do tipo statusParcela que ir� ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<StatusParcela> Consultar(StatusParcela statusParcela, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// M�todo respons�vel por consultar todos os coment�rios do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os statusParcelas cadastrados.</returns>
        List<StatusParcela> Consultar();
		
		/// <summary>
        /// M�todo respons�vel por confirmar as altera��es no sistema.
        /// </summary>       
		void Confirmar();
    }
}