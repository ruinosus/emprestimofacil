using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;

using SiteMVCTelerik.ModuloStatusParcela.Excecoes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloStatusParcela.Repositorios
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
                db.AddToStatusParcelaSet(statusParcela);
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

                db.DeleteObject(statusParcelaAux);

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
                statusParcelaAux = resultado[0];
                statusParcelaAux.descricao = statusParcela.descricao;
                statusParcelaAux.ID = statusParcela.ID;
               

               

                Confirmar();
            }
            catch (Exception)
            {

                throw new StatusParcelaNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public StatusParcelaRepositorio()
        {
          
            db = new EmprestimoEntities();

        }
        #endregion


    }
}