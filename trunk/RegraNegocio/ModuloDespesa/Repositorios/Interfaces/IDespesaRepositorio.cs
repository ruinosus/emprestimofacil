using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloBasico.Enums;

namespace Negocios.ModuloDespesa.Repositorios
{
    /// <summary>
    /// Interface IDespesaRepositorio
    /// </summary>
    public interface IDespesaRepositorio
    {
        /// <summary>
        /// M�todo respons�vel por incluir uma despesa no sistema.
        /// </summary>
        /// <param name="despesa">Objeto do tipo despesa a ser incluido.</param>
        void Incluir(Despesa despesa);

        /// <summary>
        /// M�todo respons�vel por excluir uma despesa do sistema.
        /// </summary>
        /// <param name="despesa">Objeto do tipo despesa a ser excluido.</param>
        void Excluir(Despesa despesa);

        /// <summary>
        /// M�todo repons�vel por alterar uma despesa do sistema.
        /// </summary>
        /// <param name="despesa">Objeto do tipo despesa a ser alterado.</param>
        void Alterar(Despesa despesa);

        /// <summary>
        /// M�todo respons�vel por consultar despesas do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="despesa">Objeto do tipo despesa que ir� ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todas as despesas cadastradas.</returns>
        List<Despesa> Consultar(Despesa despesa, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// M�todo respons�vel por consultar todas as despesas do sistema.
        /// </summary>
        /// <returns>Lista contendo todas as despesas cadastradas.</returns>
        List<Despesa> Consultar();
		
		/// <summary>
        /// M�todo respons�vel por confirmar as altera��es no sistema.
        /// </summary>       
		void Confirmar();
    }
}