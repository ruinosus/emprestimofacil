using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using Negocios.ModuloUsuarioTipo.Excecoes;
using Negocios.ModuloBasico.Enums;
using Negocios.ModuloBasico.VOs;

namespace Negocios.ModuloUsuarioTipo.Repositorios
{
    public class UsuarioTipoRepositorio : IUsuarioTipoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<UsuarioTipo> Consultar()
        {
            return db.UsuarioTipoSet.ToList();
        }

        public List<UsuarioTipo> Consultar(UsuarioTipo usuarioTipo, TipoPesquisa tipoPesquisa)
        {
            List<UsuarioTipo> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (usuarioTipo.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == usuarioTipo.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuarioTipo.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == usuarioTipo.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuarioTipo.Agencia))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Agencia.Contains(usuarioTipo.Agencia)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuarioTipo.Banco))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Banco.Contains(usuarioTipo.Banco)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuarioTipo.Conta))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Conta.Contains(usuarioTipo.Conta)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuarioTipo.Cpf))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Cpf.Contains(usuarioTipo.Cpf)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuarioTipo.Tipo != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Tipo == usuarioTipo.Tipo
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (usuarioTipo.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == usuarioTipo.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuarioTipo.NumUsuarioTipo.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.NumUsuarioTipo.HasValue && c.NumUsuarioTipo.Value == usuarioTipo.NumUsuarioTipo.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuarioTipo.Status.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Status.HasValue && c.Status.Value == usuarioTipo.Status.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuarioTipo.Valor.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Valor.HasValue && c.Valor.Value == usuarioTipo.Valor.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (usuarioTipo.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == usuarioTipo.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuarioTipo.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == usuarioTipo.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuarioTipo.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(usuarioTipo.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuarioTipo.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(usuarioTipo.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuarioTipo.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(usuarioTipo.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuarioTipo.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(usuarioTipo.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuarioTipo.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == usuarioTipo.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (usuarioTipo.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == usuarioTipo.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuarioTipo.NumUsuarioTipo.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumUsuarioTipo.HasValue && c.NumUsuarioTipo.Value == usuarioTipo.NumUsuarioTipo.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuarioTipo.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == usuarioTipo.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuarioTipo.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == usuarioTipo.Valor.Value
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

        public void Incluir(UsuarioTipo usuarioTipo)
        {
            try
            {
                db.UsuarioTipo.InsertOnSubmit(usuarioTipo);
            }
            catch (Exception)
            {

                throw new UsuarioTipoNaoIncluidoExcecao();
            }
        }

        public void Excluir(UsuarioTipo usuarioTipo)
        {
            try
            {
                UsuarioTipo usuarioTipoAux = new UsuarioTipo();
                usuarioTipoAux.ID = usuarioTipo.ID;


                List<UsuarioTipo> resultado = this.Consultar(usuarioTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new UsuarioTipoNaoExcluidoExcecao();

                usuarioTipoAux = resultado[0];

                db.UsuarioTipo.DeleteOnSubmit(usuarioTipoAux);

            }
            catch (Exception)
            {

                throw new UsuarioTipoNaoExcluidoExcecao();
            }
        }

        public void Alterar(UsuarioTipo usuarioTipo)
        {
            try
            {
                UsuarioTipo usuarioTipoAux = new UsuarioTipo();
                usuarioTipoAux.ID = usuarioTipo.ID;


                List<UsuarioTipo> resultado = this.Consultar(usuarioTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new UsuarioTipoNaoAlteradoExcecao();

                usuarioTipoAux.Agencia = usuarioTipo.Agencia;
                usuarioTipoAux.Banco = usuarioTipo.Banco;
                usuarioTipoAux.Conta = usuarioTipo.Conta;
                usuarioTipoAux.Cpf = usuarioTipo.Cpf;
                usuarioTipoAux.NumUsuarioTipo = usuarioTipo.NumUsuarioTipo;
                usuarioTipoAux.Parcela = usuarioTipo.Parcela;
                usuarioTipoAux.Status = usuarioTipo.Status;
                usuarioTipoAux.Tipo = usuarioTipo.Tipo;
                usuarioTipoAux.Valor = usuarioTipo.Valor;

                usuarioTipoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new UsuarioTipoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public UsuarioTipoRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new EmprestimoEntities(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}