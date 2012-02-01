using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloBloqueado.Processos
{
    /// <summary>
    /// Summary description for IBloqueadoRepositorio
    /// </summary>
    public interface IBloqueadoProcesso
    {
        /// <summary>
        /// Método responsável por incluir um bloqueado no sistema.
        /// </summary>
        /// <param name="bloqueado">Objeto do tipo bloqueado a ser incluido.</param>
        void Incluir(Bloqueado bloqueado);

        /// <summary>
        /// Método responsável por excluir um bloqueado do sistema.
        /// </summary>
        /// <param name="bloqueado">Objeto do tipo bloqueado a ser excluido.</param>
        void Excluir(Bloqueado bloqueado);

        /// <summary>
        /// Método reponsável por alterar um bloqueado do sistema.
        /// </summary>
        /// <param name="bloqueado">Objeto do tipo bloqueado a ser alterado.</param>
        void Alterar(Bloqueado bloqueado);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="bloqueado">Objeto do tipo bloqueado que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<Bloqueado> Consultar(Bloqueado bloqueado, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os bloqueados cadastrados.</returns>
        List<Bloqueado> Consultar();

        /// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
        void Confirmar();
    }
}