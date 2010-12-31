using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using Negocios.ModuloStatusParcela.Excecoes;
using Negocios.ModuloBasico.Enums;
using Negocios.ModuloBasico.VOs;

namespace Negocios.ModuloStatusParcela.Repositorios
{
    public class StatusParcelaRepositorio : IStatusParcelaRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<StatusParcela> Consultar()
        {
            return db.StatusParcelaSet.ToList();
        }

        public List<StatusParcela> Consultar(StatusParcela statusParcela, TipoPesquisa tipoPesquisa)
        {
            List<StatusParcela> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (statusParcela.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == statusParcela.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (statusParcela.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == statusParcela.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(statusParcela.Agencia))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Agencia.Contains(statusParcela.Agencia)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(statusParcela.Banco))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Banco.Contains(statusParcela.Banco)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(statusParcela.Conta))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Conta.Contains(statusParcela.Conta)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(statusParcela.Cpf))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Cpf.Contains(statusParcela.Cpf)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (statusParcela.Tipo != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Tipo == statusParcela.Tipo
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (statusParcela.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == statusParcela.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (statusParcela.NumStatusParcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.NumStatusParcela.HasValue && c.NumStatusParcela.Value == statusParcela.NumStatusParcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (statusParcela.Status.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Status.HasValue && c.Status.Value == statusParcela.Status.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (statusParcela.Valor.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Valor.HasValue && c.Valor.Value == statusParcela.Valor.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (statusParcela.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == statusParcela.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (statusParcela.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == statusParcela.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(statusParcela.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(statusParcela.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(statusParcela.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(statusParcela.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(statusParcela.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(statusParcela.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(statusParcela.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(statusParcela.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (statusParcela.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == statusParcela.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (statusParcela.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == statusParcela.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (statusParcela.NumStatusParcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumStatusParcela.HasValue && c.NumStatusParcela.Value == statusParcela.NumStatusParcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (statusParcela.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == statusParcela.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (statusParcela.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == statusParcela.Valor.Value
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

        public void Incluir(StatusParcela statusParcela)
        {
            try
            {
                db.StatusParcela.InsertOnSubmit(statusParcela);
            }
            catch (Exception)
            {

                throw new StatusParcelaNaoIncluidoExcecao();
            }
        }

        public void Excluir(StatusParcela statusParcela)
        {
            try
            {
                StatusParcela statusParcelaAux = new StatusParcela();
                statusParcelaAux.ID = statusParcela.ID;


                List<StatusParcela> resultado = this.Consultar(statusParcelaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new StatusParcelaNaoExcluidoExcecao();

                statusParcelaAux = resultado[0];

                db.StatusParcela.DeleteOnSubmit(statusParcelaAux);

            }
            catch (Exception)
            {

                throw new StatusParcelaNaoExcluidoExcecao();
            }
        }

        public void Alterar(StatusParcela statusParcela)
        {
            try
            {
                StatusParcela statusParcelaAux = new StatusParcela();
                statusParcelaAux.ID = statusParcela.ID;


                List<StatusParcela> resultado = this.Consultar(statusParcelaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new StatusParcelaNaoAlteradoExcecao();

                statusParcelaAux.Agencia = statusParcela.Agencia;
                statusParcelaAux.Banco = statusParcela.Banco;
                statusParcelaAux.Conta = statusParcela.Conta;
                statusParcelaAux.Cpf = statusParcela.Cpf;
                statusParcelaAux.NumStatusParcela = statusParcela.NumStatusParcela;
                statusParcelaAux.Parcela = statusParcela.Parcela;
                statusParcelaAux.Status = statusParcela.Status;
                statusParcelaAux.Tipo = statusParcela.Tipo;
                statusParcelaAux.Valor = statusParcela.Valor;

                statusParcelaAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new StatusParcelaNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public StatusParcelaRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new EmprestimoEntities(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}