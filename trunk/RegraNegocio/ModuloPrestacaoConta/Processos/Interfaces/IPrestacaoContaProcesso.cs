using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloPrestacaoConta.Processos
{
    /// <summary>
    /// Interface IPrestacaoContaRepositorio
    /// </summary>
    public interface IPrestacaoContaProcesso
    {
        /// <summary>
        /// M�todo respons�vel por incluir uma prestacaoConta no sistema.
        /// </summary>
        /// <param name="prestacaoConta">Objeto do tipo prestacaoConta a ser incluido.</param>
        void Incluir(PrestacaoConta prestacaoConta);

        /// <summary>
        /// M�todo respons�vel por excluir uma prestacaoConta do sistema.
        /// </summary>
        /// <param name="prestacaoConta">Objeto do tipo prestacaoConta a ser excluido.</param>
        void Excluir(PrestacaoConta prestacaoConta);

        /// <summary>
        /// M�todo repons�vel por alterar uma prestacaoConta do sistema.
        /// </summary>
        /// <param name="prestacaoConta">Objeto do tipo prestacaoConta a ser alterado.</param>
        void Alterar(PrestacaoConta prestacaoConta);

        /// <summary>
        /// M�todo respons�vel por consultar prestacaoContas do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="prestacaoConta">Objeto do tipo prestacaoConta que ir� ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todas as prestacaoContas cadastradas.</returns>
        List<PrestacaoConta> Consultar(PrestacaoConta prestacaoConta, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// M�todo respons�vel por consultar todas as prestacaoContas do sistema.
        /// </summary>
        /// <returns>Lista contendo todas as prestacaoContas cadastradas.</returns>
        List<PrestacaoConta> Consultar();

        /// <summary>
        /// M�todo respons�vel por confirmar as altera��es no sistema.
        /// </summary>       
        void Confirmar();
    }
}