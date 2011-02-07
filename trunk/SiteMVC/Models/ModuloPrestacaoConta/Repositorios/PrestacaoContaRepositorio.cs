using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;

using SiteMVC.ModuloPrestacaoConta.Excecoes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloPrestacaoConta.Repositorios
{
    public class PrestacaoContaRepositorio : IPrestacaoContaRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<PrestacaoConta> Consultar()
        {
            return db.PrestacaoContaSet.ToList();
        }

        public List<PrestacaoConta> Consultar(PrestacaoConta prestacaoConta, TipoPesquisa tipoPesquisa)
        {
            List<PrestacaoConta> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (prestacaoConta.ID != 0)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.ID == prestacaoConta.ID
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }
                        else
                        {
                            if (prestacaoConta.dataprestacao != default(DateTime))
                            {

                                resultado = ((from t in resultado
                                              where
                                              t.dataprestacao.Date.Equals(prestacaoConta.dataprestacao.Date)
                                              select t).ToList());

                                resultado = resultado.Distinct().ToList();
                            }
                        }
                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (prestacaoConta.ID != 0)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.ID == prestacaoConta.ID
                                                select t).ToList());

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

        public void Incluir(PrestacaoConta prestacaoConta)
        {
            try
            {
                db.AddToPrestacaoContaSet(prestacaoConta);
            }
            catch (Exception)
            {

                throw new PrestacaoContaNaoIncluidaExcecao();
            }
        }

        public void Excluir(PrestacaoConta prestacaoConta)
        {
            try
            {
                PrestacaoConta prestacaoContaAux = new PrestacaoConta();
                prestacaoContaAux.ID = prestacaoConta.ID;

                List<PrestacaoConta> resultado = this.Consultar(prestacaoContaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new PrestacaoContaNaoExcluidaExcecao();

                prestacaoContaAux = resultado[0];

                db.DeleteObject(prestacaoContaAux);
            }
            catch (Exception)
            {

                throw new PrestacaoContaNaoExcluidaExcecao();
            }
        }

        public void Alterar(PrestacaoConta prestacaoConta)
        {
            try
            {
                PrestacaoConta prestacaoContaAux = new PrestacaoConta();
                prestacaoContaAux.ID = prestacaoConta.ID;

                List<PrestacaoConta> resultado = this.Consultar(prestacaoContaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new PrestacaoContaNaoAlteradaExcecao();

                prestacaoContaAux = resultado[0];
                prestacaoContaAux.dataprestacao = prestacaoConta.dataprestacao;
                prestacaoContaAux.ID = prestacaoConta.ID;
                prestacaoContaAux.totaldespesas = prestacaoConta.totaldespesas;
                prestacaoContaAux.usuario_id = prestacaoConta.usuario_id;
                prestacaoContaAux.valorcancelado = prestacaoConta.valorcancelado;
                prestacaoContaAux.valordevolvido = prestacaoConta.valordevolvido;
                prestacaoContaAux.valoremprestado = prestacaoConta.valoremprestado;
                prestacaoContaAux.valorrecebido = prestacaoConta.valorrecebido;
                prestacaoContaAux.valorsaida = prestacaoConta.valorsaida;
                
                Confirmar();
            }
            catch (Exception)
            {

                throw new PrestacaoContaNaoAlteradaExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public PrestacaoContaRepositorio()
        {
            db = new EmprestimoEntities();
        }
        #endregion


    }
}