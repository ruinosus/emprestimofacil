using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using Negocios.ModuloUsuario.Excecoes;
using Negocios.ModuloBasico.Enums;
using Negocios.ModuloBasico.VOs;

namespace Negocios.ModuloUsuario.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        #region Atributos

        ColegioDB db;

        #endregion

        #region Métodos da Interface

        public List<Usuario> Consultar()
        {
            return db.Usuario.ToList();
        }

        public List<Usuario> Consultar(Usuario usuario, TipoPesquisa tipoPesquisa)
        {
            List<Usuario> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (usuario.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == usuario.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuario.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == usuario.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuario.Agencia))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Agencia.Contains(usuario.Agencia)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuario.Banco))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Banco.Contains(usuario.Banco)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuario.Conta))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Conta.Contains(usuario.Conta)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuario.Cpf))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Cpf.Contains(usuario.Cpf)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuario.Tipo != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Tipo == usuario.Tipo
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (usuario.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == usuario.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuario.NumUsuario.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.NumUsuario.HasValue && c.NumUsuario.Value == usuario.NumUsuario.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuario.Status.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Status.HasValue && c.Status.Value == usuario.Status.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuario.Valor.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Valor.HasValue && c.Valor.Value == usuario.Valor.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (usuario.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == usuario.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuario.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == usuario.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuario.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(usuario.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuario.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(usuario.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuario.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(usuario.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(usuario.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(usuario.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuario.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == usuario.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (usuario.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == usuario.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuario.NumUsuario.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumUsuario.HasValue && c.NumUsuario.Value == usuario.NumUsuario.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuario.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == usuario.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (usuario.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == usuario.Valor.Value
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

        public void Incluir(Usuario usuario)
        {
            try
            {
                db.Usuario.InsertOnSubmit(usuario);
            }
            catch (Exception)
            {

                throw new UsuarioNaoIncluidoExcecao();
            }
        }

        public void Excluir(Usuario usuario)
        {
            try
            {
                Usuario usuarioAux = new Usuario();
                usuarioAux.ID = usuario.ID;


                List<Usuario> resultado = this.Consultar(usuarioAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new UsuarioNaoExcluidoExcecao();

                usuarioAux = resultado[0];

                db.Usuario.DeleteOnSubmit(usuarioAux);

            }
            catch (Exception)
            {

                throw new UsuarioNaoExcluidoExcecao();
            }
        }

        public void Alterar(Usuario usuario)
        {
            try
            {
                Usuario usuarioAux = new Usuario();
                usuarioAux.ID = usuario.ID;


                List<Usuario> resultado = this.Consultar(usuarioAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new UsuarioNaoAlteradoExcecao();

                usuarioAux.Agencia = usuario.Agencia;
                usuarioAux.Banco = usuario.Banco;
                usuarioAux.Conta = usuario.Conta;
                usuarioAux.Cpf = usuario.Cpf;
                usuarioAux.NumUsuario = usuario.NumUsuario;
                usuarioAux.Parcela = usuario.Parcela;
                usuarioAux.Status = usuario.Status;
                usuarioAux.Tipo = usuario.Tipo;
                usuarioAux.Valor = usuario.Valor;

                usuarioAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new UsuarioNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public UsuarioRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new ColegioDB(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}