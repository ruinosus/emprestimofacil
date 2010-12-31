using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using Negocios.ModuloOrgaoExpedidorNome.Excecoes;
using Negocios.ModuloBasico.Enums;
using Negocios.ModuloBasico.VOs;

namespace Negocios.ModuloOrgaoExpedidorNome.Repositorios
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

                        if (orgaoExpedidorNome.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == orgaoExpedidorNome.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(orgaoExpedidorNome.Agencia))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Agencia.Contains(orgaoExpedidorNome.Agencia)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(orgaoExpedidorNome.Banco))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Banco.Contains(orgaoExpedidorNome.Banco)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(orgaoExpedidorNome.Conta))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Conta.Contains(orgaoExpedidorNome.Conta)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(orgaoExpedidorNome.Cpf))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Cpf.Contains(orgaoExpedidorNome.Cpf)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (orgaoExpedidorNome.Tipo != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Tipo == orgaoExpedidorNome.Tipo
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (orgaoExpedidorNome.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == orgaoExpedidorNome.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (orgaoExpedidorNome.NumOrgaoExpedidorNome.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.NumOrgaoExpedidorNome.HasValue && c.NumOrgaoExpedidorNome.Value == orgaoExpedidorNome.NumOrgaoExpedidorNome.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (orgaoExpedidorNome.Status.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Status.HasValue && c.Status.Value == orgaoExpedidorNome.Status.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (orgaoExpedidorNome.Valor.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Valor.HasValue && c.Valor.Value == orgaoExpedidorNome.Valor.Value
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

                        if (orgaoExpedidorNome.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == orgaoExpedidorNome.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(orgaoExpedidorNome.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(orgaoExpedidorNome.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(orgaoExpedidorNome.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(orgaoExpedidorNome.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(orgaoExpedidorNome.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(orgaoExpedidorNome.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(orgaoExpedidorNome.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(orgaoExpedidorNome.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (orgaoExpedidorNome.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == orgaoExpedidorNome.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (orgaoExpedidorNome.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == orgaoExpedidorNome.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (orgaoExpedidorNome.NumOrgaoExpedidorNome.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumOrgaoExpedidorNome.HasValue && c.NumOrgaoExpedidorNome.Value == orgaoExpedidorNome.NumOrgaoExpedidorNome.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (orgaoExpedidorNome.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == orgaoExpedidorNome.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (orgaoExpedidorNome.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == orgaoExpedidorNome.Valor.Value
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
                db.OrgaoExpedidorNome.InsertOnSubmit(orgaoExpedidorNome);
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

                db.OrgaoExpedidorNome.DeleteOnSubmit(orgaoExpedidorNomeAux);

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

                orgaoExpedidorNomeAux.Agencia = orgaoExpedidorNome.Agencia;
                orgaoExpedidorNomeAux.Banco = orgaoExpedidorNome.Banco;
                orgaoExpedidorNomeAux.Conta = orgaoExpedidorNome.Conta;
                orgaoExpedidorNomeAux.Cpf = orgaoExpedidorNome.Cpf;
                orgaoExpedidorNomeAux.NumOrgaoExpedidorNome = orgaoExpedidorNome.NumOrgaoExpedidorNome;
                orgaoExpedidorNomeAux.Parcela = orgaoExpedidorNome.Parcela;
                orgaoExpedidorNomeAux.Status = orgaoExpedidorNome.Status;
                orgaoExpedidorNomeAux.Tipo = orgaoExpedidorNome.Tipo;
                orgaoExpedidorNomeAux.Valor = orgaoExpedidorNome.Valor;

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
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public OrgaoExpedidorNomeRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new EmprestimoEntities(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}