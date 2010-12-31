using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using Negocios.ModuloCliente.Excecoes;
using Negocios.ModuloBasico.Enums;
using Negocios.ModuloBasico.VOs;

namespace Negocios.ModuloCliente.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Cliente> Consultar()
        {
            return db.ClienteSet.ToList();
        }

        public List<Cliente> Consultar(Cliente cliente, TipoPesquisa tipoPesquisa)
        {
            List<Cliente> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (cliente.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == cliente.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (cliente.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == cliente.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(cliente.Agencia))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Agencia.Contains(cliente.Agencia)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(cliente.Banco))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Banco.Contains(cliente.Banco)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(cliente.Conta))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Conta.Contains(cliente.Conta)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(cliente.Cpf))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Cpf.Contains(cliente.Cpf)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (cliente.Tipo != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Tipo == cliente.Tipo
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (cliente.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == cliente.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (cliente.NumCliente.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.NumCliente.HasValue && c.NumCliente.Value == cliente.NumCliente.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (cliente.Status.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Status.HasValue && c.Status.Value == cliente.Status.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (cliente.Valor.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Valor.HasValue && c.Valor.Value == cliente.Valor.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (cliente.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == cliente.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (cliente.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == cliente.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(cliente.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(cliente.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(cliente.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(cliente.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(cliente.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(cliente.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(cliente.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(cliente.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (cliente.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == cliente.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (cliente.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == cliente.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (cliente.NumCliente.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumCliente.HasValue && c.NumCliente.Value == cliente.NumCliente.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (cliente.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == cliente.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (cliente.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == cliente.Valor.Value
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

        public void Incluir(Cliente cliente)
        {
            try
            {
                db.Cliente.InsertOnSubmit(cliente);
            }
            catch (Exception)
            {

                throw new ClienteNaoIncluidoExcecao();
            }
        }

        public void Excluir(Cliente cliente)
        {
            try
            {
                Cliente clienteAux = new Cliente();
                clienteAux.ID = cliente.ID;


                List<Cliente> resultado = this.Consultar(clienteAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new ClienteNaoExcluidoExcecao();

                clienteAux = resultado[0];

                db.Cliente.DeleteOnSubmit(clienteAux);

            }
            catch (Exception)
            {

                throw new ClienteNaoExcluidoExcecao();
            }
        }

        public void Alterar(Cliente cliente)
        {
            try
            {
                Cliente clienteAux = new Cliente();
                clienteAux.ID = cliente.ID;


                List<Cliente> resultado = this.Consultar(clienteAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new ClienteNaoAlteradoExcecao();

                clienteAux.Agencia = cliente.Agencia;
                clienteAux.Banco = cliente.Banco;
                clienteAux.Conta = cliente.Conta;
                clienteAux.Cpf = cliente.Cpf;
                clienteAux.NumCliente = cliente.NumCliente;
                clienteAux.Parcela = cliente.Parcela;
                clienteAux.Status = cliente.Status;
                clienteAux.Tipo = cliente.Tipo;
                clienteAux.Valor = cliente.Valor;

                clienteAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new ClienteNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public ClienteRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new EmprestimoEntities(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}