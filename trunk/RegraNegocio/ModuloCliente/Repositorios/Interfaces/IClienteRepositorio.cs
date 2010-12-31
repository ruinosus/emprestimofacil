using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Enums;

namespace RegraNegocio.ModuloCliente.Repositorios
{
    /// <summary>
    /// Summary description for IClienteRepositorio
    /// </summary>
    public interface IClienteRepositorio
    {
        /// <summary>
        /// Método responsável por incluir um cliente no sistema.
        /// </summary>
        /// <param name="cliente">Objeto do tipo cliente a ser incluido.</param>
        void Incluir(Cliente cliente);

        /// <summary>
        /// Método responsável por excluir um cliente do sistema.
        /// </summary>
        /// <param name="cliente">Objeto do tipo cliente a ser excluido.</param>
        void Excluir(Cliente cliente);

        /// <summary>
        /// Método reponsável por alterar um cliente do sistema.
        /// </summary>
        /// <param name="cliente">Objeto do tipo cliente a ser alterado.</param>
        void Alterar(Cliente cliente);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="cliente">Objeto do tipo cliente que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<Cliente> Consultar(Cliente cliente, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os clientes cadastrados.</returns>
        List<Cliente> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}