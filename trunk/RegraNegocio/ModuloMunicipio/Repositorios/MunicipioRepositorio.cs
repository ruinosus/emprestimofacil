using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;

using RegraNegocio.ModuloMunicipio.Excecoes;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloMunicipio.Repositorios
{
    public class MunicipioRepositorio : IMunicipioRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Municipio> Consultar()
        {
            return db.MunicipioSet.ToList();
        }

        public List<Municipio> Consultar(Municipio municipio, TipoPesquisa tipoPesquisa)
        {
            List<Municipio> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (municipio.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == municipio.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (municipio.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == municipio.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(municipio.Agencia))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Agencia.Contains(municipio.Agencia)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(municipio.Banco))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Banco.Contains(municipio.Banco)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(municipio.Conta))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Conta.Contains(municipio.Conta)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(municipio.Cpf))
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Cpf.Contains(municipio.Cpf)
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (municipio.Tipo != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Tipo == municipio.Tipo
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (municipio.Parcela.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Parcela.HasValue && c.Parcela.Value == municipio.Parcela.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (municipio.NumMunicipio.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.NumMunicipio.HasValue && c.NumMunicipio.Value == municipio.NumMunicipio.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (municipio.Status.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Status.HasValue && c.Status.Value == municipio.Status.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (municipio.Valor.HasValue)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.Valor.HasValue && c.Valor.Value == municipio.Valor.Value
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (municipio.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == municipio.ID
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (municipio.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == municipio.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(municipio.Agencia))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Agencia.Contains(municipio.Agencia)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(municipio.Banco))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Banco.Contains(municipio.Banco)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(municipio.Conta))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Conta.Contains(municipio.Conta)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(municipio.Cpf))
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Cpf.Contains(municipio.Cpf)
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (municipio.Tipo != 0)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Tipo == municipio.Tipo
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        if (municipio.Parcela.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Parcela.HasValue && c.Parcela.Value == municipio.Parcela.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (municipio.NumMunicipio.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.NumMunicipio.HasValue && c.NumMunicipio.Value == municipio.NumMunicipio.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (municipio.Status.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Status.HasValue && c.Status.Value == municipio.Status.Value
                                                select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (municipio.Valor.HasValue)
                        {

                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.Valor.HasValue && c.Valor.Value == municipio.Valor.Value
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

        public void Incluir(Municipio municipio)
        {
            try
            {
                db.Municipio.InsertOnSubmit(municipio);
            }
            catch (Exception)
            {

                throw new MunicipioNaoIncluidoExcecao();
            }
        }

        public void Excluir(Municipio municipio)
        {
            try
            {
                Municipio municipioAux = new Municipio();
                municipioAux.ID = municipio.ID;


                List<Municipio> resultado = this.Consultar(municipioAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new MunicipioNaoExcluidoExcecao();

                municipioAux = resultado[0];

                db.Municipio.DeleteOnSubmit(municipioAux);

            }
            catch (Exception)
            {

                throw new MunicipioNaoExcluidoExcecao();
            }
        }

        public void Alterar(Municipio municipio)
        {
            try
            {
                Municipio municipioAux = new Municipio();
                municipioAux.ID = municipio.ID;


                List<Municipio> resultado = this.Consultar(municipioAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new MunicipioNaoAlteradoExcecao();

                municipioAux.Agencia = municipio.Agencia;
                municipioAux.Banco = municipio.Banco;
                municipioAux.Conta = municipio.Conta;
                municipioAux.Cpf = municipio.Cpf;
                municipioAux.NumMunicipio = municipio.NumMunicipio;
                municipioAux.Parcela = municipio.Parcela;
                municipioAux.Status = municipio.Status;
                municipioAux.Tipo = municipio.Tipo;
                municipioAux.Valor = municipio.Valor;

                municipioAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new MunicipioNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public MunicipioRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new EmprestimoEntities(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}