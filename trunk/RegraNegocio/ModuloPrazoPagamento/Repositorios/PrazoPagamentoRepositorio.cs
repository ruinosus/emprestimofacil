using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using RegraNegocio.ModuloPrazoPagamento.Excecoes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloPrazoPagamento.Repositorios
{
    public class PrazoPagamentoRepositorio : IPrazoPagamentoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<PrazoPagamento> Consultar()
        {
            return db.PrazoPagamentoSet.ToList();
        }

        public List<PrazoPagamento> Consultar(PrazoPagamento prazoPagamento, TipoPesquisa tipoPesquisa)
        {
            List<PrazoPagamento> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (prazoPagamento.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == prazoPagamento.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (prazoPagamento.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == prazoPagamento.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(prazoPagamento.Agencia))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Agencia.Contains(prazoPagamento.Agencia)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(prazoPagamento.Banco))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Banco.Contains(prazoPagamento.Banco)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(prazoPagamento.Conta))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Conta.Contains(prazoPagamento.Conta)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(prazoPagamento.Cpf))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Cpf.Contains(prazoPagamento.Cpf)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (prazoPagamento.Tipo != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Tipo == prazoPagamento.Tipo
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (prazoPagamento.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == prazoPagamento.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (prazoPagamento.NumPrazoPagamento.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.NumPrazoPagamento.HasValue && c.NumPrazoPagamento.Value == prazoPagamento.NumPrazoPagamento.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (prazoPagamento.Status.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Status.HasValue && c.Status.Value == prazoPagamento.Status.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (prazoPagamento.Valor.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Valor.HasValue && c.Valor.Value == prazoPagamento.Valor.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (prazoPagamento.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == prazoPagamento.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (prazoPagamento.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == prazoPagamento.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(prazoPagamento.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(prazoPagamento.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(prazoPagamento.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(prazoPagamento.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(prazoPagamento.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(prazoPagamento.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(prazoPagamento.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(prazoPagamento.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (prazoPagamento.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == prazoPagamento.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (prazoPagamento.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == prazoPagamento.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (prazoPagamento.NumPrazoPagamento.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumPrazoPagamento.HasValue && c.NumPrazoPagamento.Value == prazoPagamento.NumPrazoPagamento.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (prazoPagamento.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == prazoPagamento.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (prazoPagamento.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == prazoPagamento.Valor.Value
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

        public void Incluir(PrazoPagamento prazoPagamento)
        {
            try
            {
                db.PrazoPagamento.InsertOnSubmit(prazoPagamento);
            }
            catch (Exception)
            {

                throw new PrazoPagamentoNaoIncluidoExcecao();
            }
        }

        public void Excluir(PrazoPagamento prazoPagamento)
        {
            try
            {
                PrazoPagamento prazoPagamentoAux = new PrazoPagamento();
                prazoPagamentoAux.ID = prazoPagamento.ID;


                List<PrazoPagamento> resultado = this.Consultar(prazoPagamentoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new PrazoPagamentoNaoExcluidoExcecao();

                prazoPagamentoAux = resultado[0];

                db.PrazoPagamento.DeleteOnSubmit(prazoPagamentoAux);

            }
            catch (Exception)
            {

                throw new PrazoPagamentoNaoExcluidoExcecao();
            }
        }

        public void Alterar(PrazoPagamento prazoPagamento)
        {
            try
            {
                PrazoPagamento prazoPagamentoAux = new PrazoPagamento();
                prazoPagamentoAux.ID = prazoPagamento.ID;


                List<PrazoPagamento> resultado = this.Consultar(prazoPagamentoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new PrazoPagamentoNaoAlteradoExcecao();

                prazoPagamentoAux.Agencia = prazoPagamento.Agencia;
                prazoPagamentoAux.Banco = prazoPagamento.Banco;
                prazoPagamentoAux.Conta = prazoPagamento.Conta;
                prazoPagamentoAux.Cpf = prazoPagamento.Cpf;
                prazoPagamentoAux.NumPrazoPagamento = prazoPagamento.NumPrazoPagamento;
                prazoPagamentoAux.Parcela = prazoPagamento.Parcela;
                prazoPagamentoAux.Status = prazoPagamento.Status;
                prazoPagamentoAux.Tipo = prazoPagamento.Tipo;
                prazoPagamentoAux.Valor = prazoPagamento.Valor;

                prazoPagamentoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new PrazoPagamentoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public PrazoPagamentoRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new EmprestimoEntities(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}