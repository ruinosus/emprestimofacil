using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;

using RegraNegocio.ModuloOrgaoExpedidorNome.Excecoes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloOrgaoExpedidorNome.Repositorios
{
    public class OrgaoExpedidorNomeRepositorio : IOrgaoExpedidorNomeRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<OrgaoExpedidorNome> Consultar()
        {
            return db.OrgaoExpedidorNomeSet.ToList();
        }

        public List<OrgaoExpedidorNome> Consultar(OrgaoExpedidorNome orgaoExpedidorNome, TipoPesquisa tipoPesquisa)
        {
            List<OrgaoExpedidorNome> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (orgaoExpedidorNome.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == orgaoExpedidorNome.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (orgaoExpedidorNome.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == orgaoExpedidorNome.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                default:
                    break;
            }

            return resultado;
        }

        public void Incluir(OrgaoExpedidorNome orgaoExpedidorNome)
        {
            try
            {
                db.AddToOrgaoExpedidorNomeSet(orgaoExpedidorNome);
            }
            catch (Exception)
            {

                throw new OrgaoExpedidorNomeNaoIncluidoExcecao();
            }
        }

        public void Excluir(OrgaoExpedidorNome orgaoExpedidorNome)
        {
            try
            {
                OrgaoExpedidorNome orgaoExpedidorNomeAux = new OrgaoExpedidorNome();
                orgaoExpedidorNomeAux.ID = orgaoExpedidorNome.ID;


                List<OrgaoExpedidorNome> resultado = this.Consultar(orgaoExpedidorNomeAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new OrgaoExpedidorNomeNaoExcluidoExcecao();

                orgaoExpedidorNomeAux = resultado[0];

                db.DeleteObject(orgaoExpedidorNomeAux);

            }
            catch (Exception)
            {

                throw new OrgaoExpedidorNomeNaoExcluidoExcecao();
            }
        }

        public void Alterar(OrgaoExpedidorNome orgaoExpedidorNome)
        {
            try
            {
                OrgaoExpedidorNome orgaoExpedidorNomeAux = new OrgaoExpedidorNome();
                orgaoExpedidorNomeAux.ID = orgaoExpedidorNome.ID;


                List<OrgaoExpedidorNome> resultado = this.Consultar(orgaoExpedidorNomeAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new OrgaoExpedidorNomeNaoAlteradoExcecao();

                orgaoExpedidorNomeAux.descricao = orgaoExpedidorNome.descricao;
                orgaoExpedidorNomeAux.ID = orgaoExpedidorNome.ID;
              

                orgaoExpedidorNomeAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new OrgaoExpedidorNomeNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public OrgaoExpedidorNomeRepositorio()
        {
            db = new EmprestimoEntities();
        }
        #endregion


    }
}