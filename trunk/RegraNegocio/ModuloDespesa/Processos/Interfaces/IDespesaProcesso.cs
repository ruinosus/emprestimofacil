using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Enums;

namespace RegraNegocio.ModuloDespesa.Processos
{
    /// <summary>
    /// Interface IDespesaRepositorio
    /// </summary>
    public interface IDespesaProcesso
    {
        /// <summary>
        /// Método responsável por incluir uma despesa no sistema.
        /// </summary>
        /// <param name="despesa">Objeto do tipo despesa a ser incluido.</param>
        void Incluir(Despesa despesa);

        /// <summary>
        /// Método responsável por excluir uma despesa do sistema.
        /// </summary>
        /// <param name="despesa">Objeto do tipo despesa a ser excluido.</param>
        void Excluir(Despesa despesa);

        /// <summary>
        /// Método reponsável por alterar uma despesa do sistema.
        /// </summary>
        /// <param name="despesa">Objeto do tipo despesa a ser alterado.</param>
        void Alterar(Despesa despesa);

        /// <summary>
        /// Método responsável por consultar despesas do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="despesa">Objeto do tipo despesa que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todas as despesas cadastradas.</returns>
        List<Despesa> Consultar(Despesa despesa, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todas as despesas do sistema.
        /// </summary>
        /// <returns>Lista contendo todas as despesas cadastradas.</returns>
        List<Despesa> Consultar();

        /// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
        void Confirmar();
    }
}