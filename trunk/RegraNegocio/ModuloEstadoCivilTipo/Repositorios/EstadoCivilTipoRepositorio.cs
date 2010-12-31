using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using Negocios.ModuloEstadoCivilTipo.Excecoes;
using Negocios.ModuloBasico.Enums;
using Negocios.ModuloBasico.VOs;

namespace Negocios.ModuloEstadoCivilTipo.Repositorios
{
    public class EstadoCivilTipoRepositorio : IEstadoCivilTipoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<EstadoCivilTipo> Consultar()
        {
            return db.EstadoCivilTipoSet.ToList();
        }

        public List<EstadoCivilTipo> Consultar(EstadoCivilTipo estadoCivilTipo, TipoPesquisa tipoPesquisa)
        {
            List<EstadoCivilTipo> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (estadoCivilTipo.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == estadoCivilTipo.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (estadoCivilTipo.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == estadoCivilTipo.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(estadoCivilTipo.Agencia))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Agencia.Contains(estadoCivilTipo.Agencia)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(estadoCivilTipo.Banco))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Banco.Contains(estadoCivilTipo.Banco)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(estadoCivilTipo.Conta))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Conta.Contains(estadoCivilTipo.Conta)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(estadoCivilTipo.Cpf))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Cpf.Contains(estadoCivilTipo.Cpf)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (estadoCivilTipo.Tipo != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Tipo == estadoCivilTipo.Tipo
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (estadoCivilTipo.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == estadoCivilTipo.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (estadoCivilTipo.NumEstadoCivilTipo.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.NumEstadoCivilTipo.HasValue && c.NumEstadoCivilTipo.Value == estadoCivilTipo.NumEstadoCivilTipo.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (estadoCivilTipo.Status.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Status.HasValue && c.Status.Value == estadoCivilTipo.Status.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (estadoCivilTipo.Valor.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Valor.HasValue && c.Valor.Value == estadoCivilTipo.Valor.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (estadoCivilTipo.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == estadoCivilTipo.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (estadoCivilTipo.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == estadoCivilTipo.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(estadoCivilTipo.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(estadoCivilTipo.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(estadoCivilTipo.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(estadoCivilTipo.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(estadoCivilTipo.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(estadoCivilTipo.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(estadoCivilTipo.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(estadoCivilTipo.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (estadoCivilTipo.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == estadoCivilTipo.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (estadoCivilTipo.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == estadoCivilTipo.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (estadoCivilTipo.NumEstadoCivilTipo.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumEstadoCivilTipo.HasValue && c.NumEstadoCivilTipo.Value == estadoCivilTipo.NumEstadoCivilTipo.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (estadoCivilTipo.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == estadoCivilTipo.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (estadoCivilTipo.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == estadoCivilTipo.Valor.Value
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

        public void Incluir(EstadoCivilTipo estadoCivilTipo)
        {
            try
            {
                db.EstadoCivilTipo.InsertOnSubmit(estadoCivilTipo);
            }
            catch (Exception)
            {

                throw new EstadoCivilTipoNaoIncluidoExcecao();
            }
        }

        public void Excluir(EstadoCivilTipo estadoCivilTipo)
        {
            try
            {
                EstadoCivilTipo estadoCivilTipoAux = new EstadoCivilTipo();
                estadoCivilTipoAux.ID = estadoCivilTipo.ID;


                List<EstadoCivilTipo> resultado = this.Consultar(estadoCivilTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EstadoCivilTipoNaoExcluidoExcecao();

                estadoCivilTipoAux = resultado[0];

                db.EstadoCivilTipo.DeleteOnSubmit(estadoCivilTipoAux);

            }
            catch (Exception)
            {

                throw new EstadoCivilTipoNaoExcluidoExcecao();
            }
        }

        public void Alterar(EstadoCivilTipo estadoCivilTipo)
        {
            try
            {
                EstadoCivilTipo estadoCivilTipoAux = new EstadoCivilTipo();
                estadoCivilTipoAux.ID = estadoCivilTipo.ID;


                List<EstadoCivilTipo> resultado = this.Consultar(estadoCivilTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EstadoCivilTipoNaoAlteradoExcecao();

                estadoCivilTipoAux.Agencia = estadoCivilTipo.Agencia;
                estadoCivilTipoAux.Banco = estadoCivilTipo.Banco;
                estadoCivilTipoAux.Conta = estadoCivilTipo.Conta;
                estadoCivilTipoAux.Cpf = estadoCivilTipo.Cpf;
                estadoCivilTipoAux.NumEstadoCivilTipo = estadoCivilTipo.NumEstadoCivilTipo;
                estadoCivilTipoAux.Parcela = estadoCivilTipo.Parcela;
                estadoCivilTipoAux.Status = estadoCivilTipo.Status;
                estadoCivilTipoAux.Tipo = estadoCivilTipo.Tipo;
                estadoCivilTipoAux.Valor = estadoCivilTipo.Valor;

                estadoCivilTipoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new EstadoCivilTipoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public EstadoCivilTipoRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new EmprestimoEntities(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}