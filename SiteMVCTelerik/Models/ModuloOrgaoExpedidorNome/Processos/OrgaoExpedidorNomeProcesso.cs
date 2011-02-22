using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloOrgaoExpedidorNome.Repositorios;
using SiteMVCTelerik.ModuloOrgaoExpedidorNome.Processos;
using SiteMVCTelerik.ModuloOrgaoExpedidorNome.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloOrgaoExpedidorNome.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloOrgaoExpedidorNome.Processos
{
    /// <summary>
    /// Classe OrgaoExpedidorNomeProcesso
    /// </summary>
    public class OrgaoExpedidorNomeProcesso : Singleton<OrgaoExpedidorNomeProcesso>, IOrgaoExpedidorNomeProcesso
    {
        #region Atributos
        private IOrgaoExpedidorNomeRepositorio orgaoExpedidorNomeRepositorio = null;
        #endregion

        #region Construtor
        public OrgaoExpedidorNomeProcesso()
        {
            orgaoExpedidorNomeRepositorio = OrgaoExpedidorNomeFabrica.IOrgaoExpedidorNomeInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(OrgaoExpedidorNome orgaoExpedidorNome)
        {
            this.orgaoExpedidorNomeRepositorio.Incluir(orgaoExpedidorNome);

        }

        public void Excluir(OrgaoExpedidorNome orgaoExpedidorNome)
        {

            try
            {
                if (orgaoExpedidorNome.ID == 0)
                    throw new OrgaoExpedidorNomeNaoExcluidoExcecao();

                List<OrgaoExpedidorNome> resultado = orgaoExpedidorNomeRepositorio.Consultar(orgaoExpedidorNome, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new OrgaoExpedidorNomeNaoExcluidoExcecao();

                this.orgaoExpedidorNomeRepositorio.Excluir(orgaoExpedidorNome);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.orgaoExpedidorNomeRepositorio.Excluir(orgaoExpedidorNome);
        }

        public void Alterar(OrgaoExpedidorNome orgaoExpedidorNome)
        {
            this.orgaoExpedidorNomeRepositorio.Alterar(orgaoExpedidorNome);
        }

        public List<OrgaoExpedidorNome> Consultar(OrgaoExpedidorNome orgaoExpedidorNome, TipoPesquisa tipoPesquisa)
        {
            List<OrgaoExpedidorNome> orgaoExpedidorNomeList = this.orgaoExpedidorNomeRepositorio.Consultar(orgaoExpedidorNome,tipoPesquisa);           

            return orgaoExpedidorNomeList;
        }

        public List<OrgaoExpedidorNome> Consultar()
        {
            List<OrgaoExpedidorNome> orgaoExpedidorNomeList = this.orgaoExpedidorNomeRepositorio.Consultar();

            return orgaoExpedidorNomeList;
        }

     
        public void Confirmar()
        {
            this.orgaoExpedidorNomeRepositorio.Confirmar();
        }

        #endregion
    }
}