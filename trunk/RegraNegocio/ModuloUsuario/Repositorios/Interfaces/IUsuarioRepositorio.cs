using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Enums;

namespace RegraNegocio.ModuloUsuario.Repositorios
{
    /// <summary>
    /// Summary description for IUsuarioRepositorio
    /// </summary>
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Método responsável por incluir um usuario no sistema.
        /// </summary>
        /// <param name="usuario">Objeto do tipo usuario a ser incluido.</param>
        void Incluir(Usuario usuario);

        /// <summary>
        /// Método responsável por excluir um usuario do sistema.
        /// </summary>
        /// <param name="usuario">Objeto do tipo usuario a ser excluido.</param>
        void Excluir(Usuario usuario);

        /// <summary>
        /// Método reponsável por alterar um usuario do sistema.
        /// </summary>
        /// <param name="usuario">Objeto do tipo usuario a ser alterado.</param>
        void Alterar(Usuario usuario);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="usuario">Objeto do tipo usuario que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<Usuario> Consultar(Usuario usuario, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os usuarios cadastrados.</returns>
        List<Usuario> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}