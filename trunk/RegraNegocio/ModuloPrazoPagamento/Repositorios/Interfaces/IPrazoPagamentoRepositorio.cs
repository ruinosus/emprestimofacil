using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloBasico.Enums;

namespace Negocios.ModuloPrazoPagamento.Repositorios
{
    /// <summary>
    /// Summary description for IPrazoPagamentoRepositorio
    /// </summary>
    public interface IPrazoPagamentoRepositorio
    {
        /// <summary>
        /// M�todo respons�vel por incluir um prazoPagamento no sistema.
        /// </summary>
        /// <param name="prazoPagamento">Objeto do tipo prazoPagamento a ser incluido.</param>
        void Incluir(PrazoPagamento prazoPagamento);

        /// <summary>
        /// M�todo respons�vel por excluir um prazoPagamento do sistema.
        /// </summary>
        /// <param name="prazoPagamento">Objeto do tipo prazoPagamento a ser excluido.</param>
        void Excluir(PrazoPagamento prazoPagamento);

        /// <summary>
        /// M�todo repons�vel por alterar um prazoPagamento do sistema.
        /// </summary>
        /// <param name="prazoPagamento">Objeto do tipo prazoPagamento a ser alterado.</param>
        void Alterar(PrazoPagamento prazoPagamento);

        /// <summary>
        /// M�todo respons�vel por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="prazoPagamento">Objeto do tipo prazoPagamento que ir� ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<PrazoPagamento> Consultar(PrazoPagamento prazoPagamento, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// M�todo respons�vel por consultar todos os coment�rios do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os prazoPagamentos cadastrados.</returns>
        List<PrazoPagamento> Consultar();
		
		/// <summary>
        /// M�todo respons�vel por confirmar as altera��es no sistema.
        /// </summary>       
		void Confirmar();
    }
}