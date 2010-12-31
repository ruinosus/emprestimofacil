using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using MySql.Data.MySqlClient;
using Negocios.ModuloArea.Excecoes;
using Negocios.ModuloBasico.Enums;
using Negocios.ModuloBasico.VOs;

namespace Negocios.ModuloArea.Repositorios
{
    public class AreaRepositorio : IAreaRepositorio
    {
        #region Atributos

        ColegioDB db;

        #endregion

        #region Métodos da Interface

        public List<Area> Consultar()
        {
            return db.Area.ToList();
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

                        if (!string.IsNullOrEmpty(area.Nome))
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.Nome.Contains(area.Nome)
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (area.Status.HasValue)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.Status.HasValue && t.Status.Value == area.Status.Value
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

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

                        if (!string.IsNullOrEmpty(area.Nome))
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.Nome.Contains(area.Nome)
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (area.Status.HasValue)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.Status.HasValue && t.Status.Value == area.Status.Value
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

        public void Incluir(Area area)
        {
            try
            {
                db.Area.InsertOnSubmit(area);
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

                db.Area.DeleteOnSubmit(areaAux);
            }
            catch (Exception)
            {

                throw new AreaNaoExcluidaExcecao();
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
                areaAux.Nome = area.Nome;
                areaAux.Status = area.Status;


                Confirmar();
            }
            catch (Exception)
            {

                throw new AreaNaoAlteradaExcecao();
            }
        }

        public void Confirmar()
        {
            db.SubmitChanges();
        }

        #endregion

        #region Construtor
        public AreaRepositorio()
        {
            Conexao conexao = new Conexao();
            db = new ColegioDB(new MySqlConnection(conexao.ToString()));

        }
        #endregion


    }
}