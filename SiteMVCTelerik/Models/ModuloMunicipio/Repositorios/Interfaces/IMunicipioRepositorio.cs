using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloMunicipio.Repositorios
{
    /// <summary>
    /// Summary description for IMunicipioRepositorio
    /// </summary>
    public interface IMunicipioRepositorio
    {
        /// <summary>
        /// Método responsável por incluir um municipio no sistema.
        /// </summary>
        /// <param name="municipio">Objeto do tipo municipio a ser incluido.</param>
        void Incluir(Municipio municipio);

        /// <summary>
        /// Método responsável por excluir um municipio do sistema.
        /// </summary>
        /// <param name="municipio">Objeto do tipo municipio a ser excluido.</param>
        void Excluir(Municipio municipio);

        /// <summary>
        /// Método reponsável por alterar um municipio do sistema.
        /// </summary>
        /// <param name="municipio">Objeto do tipo municipio a ser alterado.</param>
        void Alterar(Municipio municipio);

        /// <summary>
        /// Método responsável por consultar perfis do sistema de acordo com os parametros informados.
        /// </summary>
        /// <param name="municipio">Objeto do tipo municipio que irá ser utilizado como parametro de pesquisa.</param>
        /// <param name="tipoPesquisa">Tipo de pesquisa a ser utilizada.</param>
        /// <returns>Lista contendo todos os perfis cadastrados.</returns>
        List<Municipio> Consultar(Municipio municipio, TipoPesquisa tipoPesquisa);

        /// <summary>
        /// Método responsável por consultar todos os comentários do sistema.
        /// </summary>
        /// <returns>Lista contendo todos os municipios cadastrados.</returns>
        List<Municipio> Consultar();
		
		/// <summary>
        /// Método responsável por confirmar as alterações no sistema.
        /// </summary>       
		void Confirmar();
    }
}