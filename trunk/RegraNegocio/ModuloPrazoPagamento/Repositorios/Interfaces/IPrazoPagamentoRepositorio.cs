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
        /// Método responsável por incluir um prazoPagamento no sistema.
        /// </summary>
        /// <param name="prazoPagamento">Objeto do tipo prazoPagamento a ser incluido.</param>
        void Incluir(PrazoPagamento prazoPagamento);

        /// <summary>
        /// Método responsável por excluir um prazoPagamento do sistema.
        /// </summary>
        /// <param name="prazoPagamento">Objeto do tipo prazoPagamento a ser excluido.</param>
        void Excluir(PrazoPagamento prazoPagamento);

        /// <summary>
        /// Método reponsável por alterar um prazoPagamento do sistema.
        /// </summary>
        /// <param name="prazoPagamento">Objeto do tipo prazoPagamento a ser alterado.</param>
        void Alterar(PrazoPagamento prazoPagamento);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="prazoPagamento">Objeto do tipo prazoPagamento que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<PrazoPagamento> Consultar(PrazoPagamento prazoPagamento, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os prazoPagamentos cadastrados.</returns>
        List<PrazoPagamento> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}