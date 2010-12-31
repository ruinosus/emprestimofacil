using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;

using RegraNegocio.ModuloEmprestimo.Excecoes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloEmprestimo.Repositorios
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region M�todos da Interface

        public List<Emprestimo> Consultar()
        {
            return db.EmprestimoSet.ToList();
        }

        public List<Emprestimo> Consultar(Emprestimo emprestimo, TipoPesquisa tipoPesquisa)
        {
            List<Emprestimo> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (emprestimo.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == emprestimo.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (emprestimo.id != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == emprestimo.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (emprestimo.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == emprestimo.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(emprestimo.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(emprestimo.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(emprestimo.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(emprestimo.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(emprestimo.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(emprestimo.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(emprestimo.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(emprestimo.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (emprestimo.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == emprestimo.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (emprestimo.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == emprestimo.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (emprestimo.NumEmprestimo.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumEmprestimo.HasValue && c.NumEmprestimo.Value == emprestimo.NumEmprestimo.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (emprestimo.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == emprestimo.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (emprestimo.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == emprestimo.Valor.Value
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

        public void Incluir(Emprestimo emprestimo)
        {
            try
            {
                db.Emprestimo.InsertOnSubmit(emprestimo);
            }
            catch (Exception)
            {

                throw new EmprestimoNaoIncluidoExcecao();
            }
        }

        public void Excluir(Emprestimo emprestimo)
        {
            try
            {
                Emprestimo emprestimoAux = new Emprestimo();
                emprestimoAux.ID = emprestimo.ID;


                List<Emprestimo> resultado = this.Consultar(emprestimoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EmprestimoNaoExcluidoExcecao();

                emprestimoAux = resultado[0];

                db.Emprestimo.DeleteOnSubmit(emprestimoAux);

            }
            catch (Exception)
            {

                throw new EmprestimoNaoExcluidoExcecao();
            }
        }

        public void Alterar(Emprestimo emprestimo)
        {
            try
            {
                Emprestimo emprestimoAux = new Emprestimo();
                emprestimoAux.ID = emprestimo.ID;


                List<Emprestimo> resultado = this.Consultar(emprestimoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EmprestimoNaoAlteradoExcecao();

                emprestimoAux.Agencia = emprestimo.Agencia;
                emprestimoAux.Banco = emprestimo.Banco;
                emprestimoAux.Conta = emprestimo.Conta;
                emprestimoAux.Cpf = emprestimo.Cpf;
                emprestimoAux.NumEmprestimo = emprestimo.NumEmprestimo;
                emprestimoAux.Parcela = emprestimo.Parcela;
                emprestimoAux.Status = emprestimo.Status;
                emprestimoAux.Tipo = emprestimo.Tipo;
                emprestimoAux.Valor = emprestimo.Valor;

                emprestimoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new EmprestimoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public EmprestimoRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new EmprestimoEntities(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}