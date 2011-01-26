using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloEmprestimo.Processos
{
    /// <summary>
    /// Summary description for IEmprestimoRepositorio
    /// </summary>
    public interface IEmprestimoProcesso
    {
        /// <summary>
        /// Método responsável por incluir um emprestimo no sistema.
        /// </summary>
        /// <param name="emprestimo">Objeto do tipo emprestimo a ser incluido.</param>
        /// <param name="diasUteis">Dias uteis a serem contabilizados</param>
        void Incluir(Emprestimo emprestimo, List<DayOfWeek> diasUteis);

        /// <summary>
        /// Método responsável por excluir um emprestimo do sistema.
        /// </summary>
        /// <param name="emprestimo">Objeto do tipo emprestimo a ser excluido.</param>
        void Excluir(Emprestimo emprestimo);

        /// <summary>
        /// Método reponsável por alterar um emprestimo do sistema.
        /// </summary>
        /// <param name="emprestimo">Objeto do tipo emprestimo a ser alterado.</param>
        void Alterar(Emprestimo emprestimo);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="emprestimo">Objeto do tipo emprestimo que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<Emprestimo> Consultar(Emprestimo emprestimo, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os emprestimos cadastrados.</returns>
        List<Emprestimo> Consultar();

        /// <summary>
        /// Método responsável por consultar todos os emprestimos realizados no periodo informado.
        /// </summary>
        /// <param name="dataInicio">Data inicial para pesquisa dos emprestimos.</param>
        /// <param name="dataFim">Data fim para pesquisa dos emprestimos.</param>
        /// <returns>Lista contendo todos os emprestimos cadastrados.</returns>
        List<Emprestimo> ConsultarEmprestimosPorPeriodo(DateTime dataInicio, DateTime dataFim);

        /// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
        void Confirmar();
    }
}