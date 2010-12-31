using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloEstadoCivilTipo.Repositorios
{
    /// <summary>
    /// Summary description for IEstadoCivilTipoRepositorio
    /// </summary>
    public interface IEstadoCivilTipoRepositorio
    {
        /// <summary>
        /// Método responsável por incluir um estadoCivilTipo no sistema.
        /// </summary>
        /// <param name="estadoCivilTipo">Objeto do tipo estadoCivilTipo a ser incluido.</param>
        void Incluir(EstadoCivilTipo estadoCivilTipo);

        /// <summary>
        /// Método responsável por excluir um estadoCivilTipo do sistema.
        /// </summary>
        /// <param name="estadoCivilTipo">Objeto do tipo estadoCivilTipo a ser excluido.</param>
        void Excluir(EstadoCivilTipo estadoCivilTipo);

        /// <summary>
        /// Método reponsável por alterar um estadoCivilTipo do sistema.
        /// </summary>
        /// <param name="estadoCivilTipo">Objeto do tipo estadoCivilTipo a ser alterado.</param>
        void Alterar(EstadoCivilTipo estadoCivilTipo);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="estadoCivilTipo">Objeto do tipo estadoCivilTipo que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<EstadoCivilTipo> Consultar(EstadoCivilTipo estadoCivilTipo, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os estadoCivilTipos cadastrados.</returns>
        List<EstadoCivilTipo> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}