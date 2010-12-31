using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloLancamentoTipo.Processos
{
    /// <summary>
    /// Summary description for ILancamentoTipoRepositorio
    /// </summary>
    public interface ILancamentoTipoProcesso
    {
        /// <summary>
        /// Método responsável por incluir um lancamentoTipo no sistema.
        /// </summary>
        /// <param name="lancamentoTipo">Objeto do tipo lancamentoTipo a ser incluido.</param>
        void Incluir(LancamentoTipo lancamentoTipo);

        /// <summary>
        /// Método responsável por excluir um lancamentoTipo do sistema.
        /// </summary>
        /// <param name="lancamentoTipo">Objeto do tipo lancamentoTipo a ser excluido.</param>
        void Excluir(LancamentoTipo lancamentoTipo);

        /// <summary>
        /// Método reponsável por alterar um lancamentoTipo do sistema.
        /// </summary>
        /// <param name="lancamentoTipo">Objeto do tipo lancamentoTipo a ser alterado.</param>
        void Alterar(LancamentoTipo lancamentoTipo);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="lancamentoTipo">Objeto do tipo lancamentoTipo que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<LancamentoTipo> Consultar(LancamentoTipo lancamentoTipo, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os lancamentoTipos cadastrados.</returns>
        List<LancamentoTipo> Consultar();

        /// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
        void Confirmar();
    }
}