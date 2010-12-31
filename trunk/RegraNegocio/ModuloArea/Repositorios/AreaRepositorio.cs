using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloArea.Excecoes;
using RegraNegocio.ModuloBasico;
using RegraNegocio.ModuloBasico.VOs;



namespace Negocios.ModuloArea.Repositorios
{
    public class AreaRepositorio : IAreaRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Area> Consultar()
        {
            return db.AreaSet.ToList();
        }

        public List<Area> Consultar(Area area, TipoPesquisa tipoPesquisa)
        {
            List<Area> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (area.ID != 0)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.ID == area.ID
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(area.descricao))
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.descricao.Contains(area.descricao)
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        //if (area.Status.HasValue)
                        //{

                        //    resultado = ((from t in resultado
                        //                  where
                        //                  t.Status.HasValue && t.Status.Value == area.Status.Value
                        //                  select t).ToList());

                        //    resultado = resultado.Distinct().ToList();
                        //}

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (area.ID != 0)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.ID == area.ID
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(area.descricao))
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.descricao.Contains(area.descricao)
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        //if (area.Status.HasValue)
                        //{

                        //    resultado.AddRange((from t in Consultar()
                        //                        where
                        //                        t.Status.HasValue && t.Status.Value == area.Status.Value
                        //                        select t).ToList());

                        //    resultado = resultado.Distinct().ToList();
                        //}

                        break;
                    }
                #endregion
                default:
                    break;
            }

            return resultado;
        }

        public void Incluir(Area area)
        {
            try
            {
                db.AddToAreaSet(area);
            }
            catch (Exception)
            {

                throw new AreaNaoIncluidaExcecao();
            }
        }

        public void Excluir(Area area)
        {
            try
            {
                Area areaAux = new Area();
                areaAux.ID = area.ID;

                List<Area> resultado = this.Consultar(areaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new AreaNaoExcluidaExcecao();

                areaAux = resultado[0];

                db.DeleteObject(areaAux);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Alterar(Area area)
        {
            try
            {
                Area areaAux = new Area();
                areaAux.ID = area.ID;

                List<Area> resultado = this.Consultar(areaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new AreaNaoAlteradaExcecao();

                areaAux = resultado[0];
                areaAux.municipio_id = area.municipio_id;
                areaAux.timeCreated= area.timeCreated;
                areaAux.timeUpdated = area.timeUpdated;
                areaAux.descricao = area.descricao;


                Confirmar();
            }
            catch (Exception)
            {

                throw new AreaNaoAlteradaExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public AreaRepositorio()
        {
            
            db = new EmprestimoEntities();

        }
        #endregion


    }
}