using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloTipoEmprestimo.Repositorios
{
    /// <summary>
    /// Summary description for ITipoEmprestimoRepositorio
    /// </summary>
    public interface ITipoEmprestimoRepositorio
    {
        /// <summary>
        /// M�todo respons�vel por incluir um tipoEmprestimo no sistema.
        /// </summary>
        /// <param name="tipoEmprestimo">Objeto do tipo tipoEmprestimo a ser incluido.</param>
        void Incluir(TipoEmprestimo tipoEmprestimo);

        /// <summary>
        /// M�todo respons�vel por excluir um tipoEmprestimo do sistema.
        /// </summary>
        /// <param name="tipoEmprestimo">Objeto do tipo tipoEmprestimo a ser excluido.</param>
        void Excluir(TipoEmprestimo tipoEmprestimo);

        /// <summary>
        /// M�todo repons�vel por alterar um tipoEmprestimo do sistema.
        /// </summary>
        /// <param name="tipoEmprestimo">Objeto do tipo tipoEmprestimo a ser alterado.</param>
        void Alterar(TipoEmprestimo tipoEmprestimo);

        /// <summary>
        /// M�todo respons�vel por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="tipoEmprestimo">Objeto do tipo tipoEmprestimo que ir� ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<TipoEmprestimo> Consultar(TipoEmprestimo tipoEmprestimo, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// M�todo respons�vel por consultar todos os coment�rios do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os tipoEmprestimos cadastrados.</returns>
        List<TipoEmprestimo> Consultar();
		
		/// <summary>
        /// M�todo respons�vel por confirmar as altera��es no sistema.
        /// </summary>       
		void Confirmar();
    }
}