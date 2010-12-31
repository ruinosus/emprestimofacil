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
        /// M�todo respons�vel por incluir um estadoCivilTipo no sistema.
        /// </summary>
        /// <param name="estadoCivilTipo">Objeto do tipo estadoCivilTipo a ser incluido.</param>
        void Incluir(EstadoCivilTipo estadoCivilTipo);

        /// <summary>
        /// M�todo respons�vel por excluir um estadoCivilTipo do sistema.
        /// </summary>
        /// <param name="estadoCivilTipo">Objeto do tipo estadoCivilTipo a ser excluido.</param>
        void Excluir(EstadoCivilTipo estadoCivilTipo);

        /// <summary>
        /// M�todo repons�vel por alterar um estadoCivilTipo do sistema.
        /// </summary>
        /// <param name="estadoCivilTipo">Objeto do tipo estadoCivilTipo a ser alterado.</param>
        void Alterar(EstadoCivilTipo estadoCivilTipo);

        /// <summary>
        /// M�todo respons�vel por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="estadoCivilTipo">Objeto do tipo estadoCivilTipo que ir� ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<EstadoCivilTipo> Consultar(EstadoCivilTipo estadoCivilTipo, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// M�todo respons�vel por consultar todos os coment�rios do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os estadoCivilTipos cadastrados.</returns>
        List<EstadoCivilTipo> Consultar();
		
		/// <summary>
        /// M�todo respons�vel por confirmar as altera��es no sistema.
        /// </summary>       
		void Confirmar();
    }
}