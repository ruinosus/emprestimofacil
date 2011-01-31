using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloUsuarioArea.Processos
{
    /// <summary>
    /// Summary description for IUsuarioAreaRepositorio
    /// </summary>
    public interface IUsuarioAreaProcesso
    {
        /// <summary>
        /// Método responsável por incluir um usuarioArea no sistema.
        /// </summary>
        /// <param name="usuarioArea">Objeto do tipo usuarioArea a ser incluido.</param>
        void Incluir(UsuarioArea usuarioArea);

        /// <summary>
        /// Método responsável por excluir um usuarioArea do sistema.
        /// </summary>
        /// <param name="usuarioArea">Objeto do tipo usuarioArea a ser excluido.</param>
        void Excluir(UsuarioArea usuarioArea);

        /// <summary>
        /// Método reponsável por alterar um usuarioArea do sistema.
        /// </summary>
        /// <param name="usuarioArea">Objeto do tipo usuarioArea a ser alterado.</param>
        void Alterar(UsuarioArea usuarioArea);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="usuarioArea">Objeto do tipo usuarioArea que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<UsuarioArea> Consultar(UsuarioArea usuarioArea, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os usuarioAreas cadastrados.</returns>
        List<UsuarioArea> Consultar();

        /// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
        void Confirmar();
    }
}