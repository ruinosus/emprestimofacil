using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using Negocios.ModuloBloqueado.Excecoes;
using Negocios.ModuloBasico.Enums;
using Negocios.ModuloBasico.VOs;

namespace Negocios.ModuloBloqueado.Repositorios
{
    public class BloqueadoRepositorio : IBloqueadoRepositorio
    {
        #region Atributos

        ColegioDB db;

        #endregion

        #region Métodos da Interface

        public List<Bloqueado> Consultar()
        {
            return db.Bloqueado.ToList();
        }

        public List<Bloqueado> Consultar(Bloqueado bloqueado, TipoPesquisa tipoPesquisa)
        {
            List<Bloqueado> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (bloqueado.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == bloqueado.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (bloqueado.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == bloqueado.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(bloqueado.Agencia))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Agencia.Contains(bloqueado.Agencia)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(bloqueado.Banco))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Banco.Contains(bloqueado.Banco)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(bloqueado.Conta))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Conta.Contains(bloqueado.Conta)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(bloqueado.Cpf))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Cpf.Contains(bloqueado.Cpf)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (bloqueado.Tipo != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Tipo == bloqueado.Tipo
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (bloqueado.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == bloqueado.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (bloqueado.NumBloqueado.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.NumBloqueado.HasValue && c.NumBloqueado.Value == bloqueado.NumBloqueado.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (bloqueado.Status.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Status.HasValue && c.Status.Value == bloqueado.Status.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (bloqueado.Valor.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Valor.HasValue && c.Valor.Value == bloqueado.Valor.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (bloqueado.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == bloqueado.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (bloqueado.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == bloqueado.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(bloqueado.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(bloqueado.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(bloqueado.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(bloqueado.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(bloqueado.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(bloqueado.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(bloqueado.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(bloqueado.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (bloqueado.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == bloqueado.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (bloqueado.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == bloqueado.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (bloqueado.NumBloqueado.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumBloqueado.HasValue && c.NumBloqueado.Value == bloqueado.NumBloqueado.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (bloqueado.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == bloqueado.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (bloqueado.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == bloqueado.Valor.Value
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

        public void Incluir(Bloqueado bloqueado)
        {
            try
            {
                db.Bloqueado.InsertOnSubmit(bloqueado);
            }
            catch (Exception)
            {

                throw new BloqueadoNaoIncluidoExcecao();
            }
        }

        public void Excluir(Bloqueado bloqueado)
        {
            try
            {
                Bloqueado bloqueadoAux = new Bloqueado();
                bloqueadoAux.ID = bloqueado.ID;


                List<Bloqueado> resultado = this.Consultar(bloqueadoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new BloqueadoNaoExcluidoExcecao();

                bloqueadoAux = resultado[0];

                db.Bloqueado.DeleteOnSubmit(bloqueadoAux);

            }
            catch (Exception)
            {

                throw new BloqueadoNaoExcluidoExcecao();
            }
        }

        public void Alterar(Bloqueado bloqueado)
        {
            try
            {
                Bloqueado bloqueadoAux = new Bloqueado();
                bloqueadoAux.ID = bloqueado.ID;


                List<Bloqueado> resultado = this.Consultar(bloqueadoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new BloqueadoNaoAlteradoExcecao();

                bloqueadoAux.Agencia = bloqueado.Agencia;
                bloqueadoAux.Banco = bloqueado.Banco;
                bloqueadoAux.Conta = bloqueado.Conta;
                bloqueadoAux.Cpf = bloqueado.Cpf;
                bloqueadoAux.NumBloqueado = bloqueado.NumBloqueado;
                bloqueadoAux.Parcela = bloqueado.Parcela;
                bloqueadoAux.Status = bloqueado.Status;
                bloqueadoAux.Tipo = bloqueado.Tipo;
                bloqueadoAux.Valor = bloqueado.Valor;

                bloqueadoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new BloqueadoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public BloqueadoRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new ColegioDB(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}