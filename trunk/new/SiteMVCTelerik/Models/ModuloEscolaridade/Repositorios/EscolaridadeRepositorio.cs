using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;

using SiteMVCTelerik.ModuloEscolaridade.Excecoes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloEscolaridade.Repositorios
{
    public class EscolaridadeRepositorio : IEscolaridadeRepositorio
    {
        #region Atributos

        emprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Escolaridade> Consultar()
        {
            return db.escolaridade.ToList();
        }

        public List<Escolaridade> Consultar(Escolaridade escolaridade, TipoPesquisa tipoPesquisa)
        {
            List<Escolaridade> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (escolaridade.id != 0)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.id == escolaridade.id
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (escolaridade.id != 0)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.id == escolaridade.id
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

        public void Incluir(Escolaridade escolaridade)
        {
            try
            {
                db.AddToescolaridade(escolaridade);
            }
            catch (Exception)
            {

                throw new EscolaridadeNaoIncluidaExcecao();
            }
        }

        public void Excluir(Escolaridade escolaridade)
        {
            try
            {
                Escolaridade escolaridadeAux = new Escolaridade();
                escolaridadeAux.id = escolaridade.id;

                List<Escolaridade> resultado = this.Consultar(escolaridadeAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EscolaridadeNaoExcluidaExcecao();

                escolaridadeAux = resultado[0];

                db.DeleteObject(escolaridadeAux);
            }
            catch (Exception)
            {

                throw new EscolaridadeNaoExcluidaExcecao();
            }
        }

        public void Alterar(Escolaridade escolaridade)
        {
            try
            {
                Escolaridade escolaridadeAux = new Escolaridade();
                escolaridadeAux.id = escolaridade.id;

                List<Escolaridade> resultado = this.Consultar(escolaridadeAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EscolaridadeNaoAlteradaExcecao();

                escolaridadeAux = resultado[0];
                escolaridadeAux.descricao = escolaridade.descricao;
                escolaridadeAux.id = escolaridade.id;
               

                Confirmar();
            }
            catch (Exception)
            {

                throw new EscolaridadeNaoAlteradaExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public EscolaridadeRepositorio()
        {
            db = new emprestimoEntities();
        }
        #endregion


    }
}