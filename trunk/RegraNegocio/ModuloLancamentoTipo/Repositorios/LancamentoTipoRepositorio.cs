using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using RegraNegocio.ModuloLancamentoTipo.Excecoes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloLancamentoTipo.Repositorios
{
    public class LancamentoTipoRepositorio : ILancamentoTipoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<LancamentoTipo> Consultar()
        {
            return db.LancamentoTipoSet.ToList();
        }

        public List<LancamentoTipo> Consultar(LancamentoTipo lancamentoTipo, TipoPesquisa tipoPesquisa)
        {
            List<LancamentoTipo> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (lancamentoTipo.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == lancamentoTipo.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamentoTipo.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == lancamentoTipo.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamentoTipo.Agencia))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Agencia.Contains(lancamentoTipo.Agencia)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamentoTipo.Banco))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Banco.Contains(lancamentoTipo.Banco)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamentoTipo.Conta))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Conta.Contains(lancamentoTipo.Conta)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamentoTipo.Cpf))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Cpf.Contains(lancamentoTipo.Cpf)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamentoTipo.Tipo != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Tipo == lancamentoTipo.Tipo
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (lancamentoTipo.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == lancamentoTipo.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamentoTipo.NumLancamentoTipo.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.NumLancamentoTipo.HasValue && c.NumLancamentoTipo.Value == lancamentoTipo.NumLancamentoTipo.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamentoTipo.Status.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Status.HasValue && c.Status.Value == lancamentoTipo.Status.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamentoTipo.Valor.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Valor.HasValue && c.Valor.Value == lancamentoTipo.Valor.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (lancamentoTipo.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == lancamentoTipo.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamentoTipo.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == lancamentoTipo.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamentoTipo.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(lancamentoTipo.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamentoTipo.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(lancamentoTipo.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamentoTipo.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(lancamentoTipo.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(lancamentoTipo.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(lancamentoTipo.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamentoTipo.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == lancamentoTipo.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (lancamentoTipo.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == lancamentoTipo.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamentoTipo.NumLancamentoTipo.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumLancamentoTipo.HasValue && c.NumLancamentoTipo.Value == lancamentoTipo.NumLancamentoTipo.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamentoTipo.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == lancamentoTipo.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (lancamentoTipo.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == lancamentoTipo.Valor.Value
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

        public void Incluir(LancamentoTipo lancamentoTipo)
        {
            try
            {
                db.LancamentoTipo.InsertOnSubmit(lancamentoTipo);
            }
            catch (Exception)
            {

                throw new LancamentoTipoNaoIncluidoExcecao();
            }
        }

        public void Excluir(LancamentoTipo lancamentoTipo)
        {
            try
            {
                LancamentoTipo lancamentoTipoAux = new LancamentoTipo();
                lancamentoTipoAux.ID = lancamentoTipo.ID;


                List<LancamentoTipo> resultado = this.Consultar(lancamentoTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new LancamentoTipoNaoExcluidoExcecao();

                lancamentoTipoAux = resultado[0];

                db.LancamentoTipo.DeleteOnSubmit(lancamentoTipoAux);

            }
            catch (Exception)
            {

                throw new LancamentoTipoNaoExcluidoExcecao();
            }
        }

        public void Alterar(LancamentoTipo lancamentoTipo)
        {
            try
            {
                LancamentoTipo lancamentoTipoAux = new LancamentoTipo();
                lancamentoTipoAux.ID = lancamentoTipo.ID;


                List<LancamentoTipo> resultado = this.Consultar(lancamentoTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new LancamentoTipoNaoAlteradoExcecao();

                lancamentoTipoAux.Agencia = lancamentoTipo.Agencia;
                lancamentoTipoAux.Banco = lancamentoTipo.Banco;
                lancamentoTipoAux.Conta = lancamentoTipo.Conta;
                lancamentoTipoAux.Cpf = lancamentoTipo.Cpf;
                lancamentoTipoAux.NumLancamentoTipo = lancamentoTipo.NumLancamentoTipo;
                lancamentoTipoAux.Parcela = lancamentoTipo.Parcela;
                lancamentoTipoAux.Status = lancamentoTipo.Status;
                lancamentoTipoAux.Tipo = lancamentoTipo.Tipo;
                lancamentoTipoAux.Valor = lancamentoTipo.Valor;

                lancamentoTipoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new LancamentoTipoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public LancamentoTipoRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new EmprestimoEntities(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}