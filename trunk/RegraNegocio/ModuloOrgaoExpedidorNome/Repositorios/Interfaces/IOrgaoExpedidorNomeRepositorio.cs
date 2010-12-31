using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloOrgaoExpedidorNome.Repositorios
{
    /// <summary>
    /// Summary description for IOrgaoExpedidorNomeRepositorio
    /// </summary>
    public interface IOrgaoExpedidorNomeRepositorio
    {
        /// <summary>
        /// Método responsável por incluir um orgaoExpedidorNome no sistema.
        /// </summary>
        /// <param name="orgaoExpedidorNome">Objeto do tipo orgaoExpedidorNome a ser incluido.</param>
        void Incluir(OrgaoExpedidorNome orgaoExpedidorNome);

        /// <summary>
        /// Método responsável por excluir um orgaoExpedidorNome do sistema.
        /// </summary>
        /// <param name="orgaoExpedidorNome">Objeto do tipo orgaoExpedidorNome a ser excluido.</param>
        void Excluir(OrgaoExpedidorNome orgaoExpedidorNome);

        /// <summary>
        /// Método reponsável por alterar um orgaoExpedidorNome do sistema.
        /// </summary>
        /// <param name="orgaoExpedidorNome">Objeto do tipo orgaoExpedidorNome a ser alterado.</param>
        void Alterar(OrgaoExpedidorNome orgaoExpedidorNome);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="orgaoExpedidorNome">Objeto do tipo orgaoExpedidorNome que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<OrgaoExpedidorNome> Consultar(OrgaoExpedidorNome orgaoExpedidorNome, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os orgaoExpedidorNomes cadastrados.</returns>
        List<OrgaoExpedidorNome> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}