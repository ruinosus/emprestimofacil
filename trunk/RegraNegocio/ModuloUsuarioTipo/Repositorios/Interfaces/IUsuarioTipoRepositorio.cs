using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloBasico.Enums;

namespace Negocios.ModuloUsuarioTipo.Repositorios
{
    /// <summary>
    /// Summary description for IUsuarioTipoRepositorio
    /// </summary>
    public interface IUsuarioTipoRepositorio
    {
        /// <summary>
        /// Método responsável por incluir um usuarioTipo no sistema.
        /// </summary>
        /// <param name="usuarioTipo">Objeto do tipo usuarioTipo a ser incluido.</param>
        void Incluir(UsuarioTipo usuarioTipo);

        /// <summary>
        /// Método responsável por excluir um usuarioTipo do sistema.
        /// </summary>
        /// <param name="usuarioTipo">Objeto do tipo usuarioTipo a ser excluido.</param>
        void Excluir(UsuarioTipo usuarioTipo);

        /// <summary>
        /// Método reponsável por alterar um usuarioTipo do sistema.
        /// </summary>
        /// <param name="usuarioTipo">Objeto do tipo usuarioTipo a ser alterado.</param>
        void Alterar(UsuarioTipo usuarioTipo);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="usuarioTipo">Objeto do tipo usuarioTipo que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<UsuarioTipo> Consultar(UsuarioTipo usuarioTipo, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os usuarioTipos cadastrados.</returns>
        List<UsuarioTipo> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}