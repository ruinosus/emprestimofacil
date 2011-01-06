using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloOrgaoExpedidorNome.Repositorios;
using SiteMVC.ModuloOrgaoExpedidorNome.Processos;
using SiteMVC.ModuloOrgaoExpedidorNome.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloOrgaoExpedidorNome.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloOrgaoExpedidorNome.Processos
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

                this.Excluir(orgaoExpedidorNome);
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