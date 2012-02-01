using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloParcela.Processos
{
    /// <summary>
    /// Interface IParcelaRepositorio
    /// </summary>
    public interface IParcelaProcesso
    {
        /// <summary>
        /// M�todo respons�vel por incluir uma parcela no sistema.
        /// </summary>
        /// <param name="parcela">Objeto do tipo parcela a ser incluido.</param>
        void Incluir(Parcela parcela);

        /// <summary>
        /// M�todo respons�vel por excluir uma parcela do sistema.
        /// </summary>
        /// <param name="parcela">Objeto do tipo parcela a ser excluido.</param>
        void Excluir(Parcela parcela);

        /// <summary>
        /// M�todo repons�vel por alterar uma parcela do sistema.
        /// </summary>
        /// <param name="parcela">Objeto do tipo parcela a ser alterado.</param>
        void Alterar(Parcela parcela);

        /// <summary>
        /// M�todo repons�vel por alterar uma parcela do sistema.
        /// </summary>
        /// <param name="parcela">Objeto do tipo parcela a ser cancelado.</param>
        void CancelarParcela(Parcela parcela);

        /// <summary>
        /// M�todo respons�vel por consultar parcelas do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="parcela">Objeto do tipo parcela que ir� ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todas as parcelas cadastradas.</returns>
        List<Parcela> Consultar(Parcela parcela, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// M�todo respons�vel por consultar todas as parcelas do sistema.
        /// </summary>
        /// <returns>Lista contendo todas as parcelas cadastradas.</returns>
        List<Parcela> Consultar();

        /// <summary>
        /// M�todo respons�vel por confirmar as altera��es no sistema.
        /// </summary>       
        void Confirmar();

        /// <summary>
        /// M�todo respons�vel por consultar todas as parcelas do periodo informado.
        /// </summary>
        /// <param name="dataInicio">Data inicial para pesquisa das parcelas.</param>
        /// <param name="dataFim">Data fim para pesquisa das parcelas.</param>
        /// <returns>Lista contendo todas as parcelas cadastradas.</returns>
        List<Parcela> ConsultarParcelasEmAbertoPorPeriodo(DateTime dataInicio, DateTime dataFim);


        /// <summary>
        /// M�todo respons�vel por consultar todas as parcelas pagas do periodo informado.
        /// </summary>
        /// <param name="dataInicio">Data inicial para pesquisa das parcelas.</param>
        /// <param name="dataFim">Data fim para pesquisa das parcelas.</param>
        /// <returns>Lista contendo todas as parcelas cadastradas.</returns>
        List<Parcela> ConsultarParcelasPagasPorPeriodo(DateTime dataInicio, DateTime dataFim);
    }
}