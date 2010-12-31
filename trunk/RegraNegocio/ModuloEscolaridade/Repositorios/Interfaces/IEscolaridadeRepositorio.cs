using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Enums;

namespace RegraNegocio.ModuloEscolaridade.Repositorios
{
    /// <summary>
    /// Interface IEscolaridadeRepositorio
    /// </summary>
    public interface IEscolaridadeRepositorio
    {
        /// <summary>
        /// Método responsável por incluir uma escolaridade no sistema.
        /// </summary>
        /// <param name="escolaridade">Objeto do tipo escolaridade a ser incluido.</param>
        void Incluir(Escolaridade escolaridade);

        /// <summary>
        /// Método responsável por excluir uma escolaridade do sistema.
        /// </summary>
        /// <param name="escolaridade">Objeto do tipo escolaridade a ser excluido.</param>
        void Excluir(Escolaridade escolaridade);

        /// <summary>
        /// Método reponsável por alterar uma escolaridade do sistema.
        /// </summary>
        /// <param name="escolaridade">Objeto do tipo escolaridade a ser alterado.</param>
        void Alterar(Escolaridade escolaridade);

        /// <summary>
        /// Método responsável por consultar escolaridades do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="escolaridade">Objeto do tipo escolaridade que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todas as escolaridades cadastradas.</returns>
        List<Escolaridade> Consultar(Escolaridade escolaridade, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todas as escolaridades do sistema.
        /// </summary>
        /// <returns>Lista contendo todas as escolaridades cadastradas.</returns>
        List<Escolaridade> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}