using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;

using SiteMVC.ModuloDespesa.Excecoes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloDespesa.Repositorios
{
    public class DespesaRepositorio : IDespesaRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Despesa> Consultar()
        {
            return db.DespesaSet.ToList();
        }

        public List<Despesa> Consultar(Despesa despesa, TipoPesquisa tipoPesquisa)
        {
            List<Despesa> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (despesa.ID != 0)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.ID == despesa.ID
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }
                        else
                        {
                            if (despesa.area_id != 0)
                            {

                                resultado = ((from t in resultado
                                              where
                                              t.area_id == despesa.area_id
                                              select t).ToList());

                                resultado = resultado.Distinct().ToList();
                            }

                            if (despesa.data != default(DateTime))
                            {

                                resultado = ((from t in resultado
                                              where
                                              t.data.Date.Equals(despesa.data.Date)
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
                        if (despesa.ID != 0)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.ID == despesa.ID
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

        public void Incluir(Despesa despesa)
        {
            try
            {
                db.AddToDespesaSet(despesa);
            }
            catch (Exception)
            {

                throw new DespesaNaoIncluidaExcecao();
            }
        }

        public void Excluir(Despesa despesa)
        {
            try
            {
                Despesa despesaAux = new Despesa();
                despesaAux.ID = despesa.ID;

                List<Despesa> resultado = this.Consultar(despesaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new DespesaNaoExcluidaExcecao();

                despesaAux = resultado[0];

                db.DeleteObject(despesaAux);
            }
            catch (Exception)
            {

                throw new DespesaNaoExcluidaExcecao();
            }
        }

        public void Alterar(Despesa despesa)
        {
            try
            {
                Despesa despesaAux = new Despesa();
                despesaAux.ID = despesa.ID;

                List<Despesa> resultado = this.Consultar(despesaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new DespesaNaoAlteradaExcecao();

                despesaAux = resultado[0];
                despesaAux.data = despesa.data;
                despesaAux.despesatipo_id = despesa.despesatipo_id;
                despesaAux.ID = despesa.ID;
                despesaAux.justificativa = despesa.justificativa;
                despesaAux.timeCreated = despesa.timeCreated;
                despesaAux.timeUpdated = despesa.timeUpdated;
                Confirmar();
            }
            catch (Exception)
            {

                throw new DespesaNaoAlteradaExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public DespesaRepositorio()
        {
            db = new EmprestimoEntities();
        }
        #endregion


    }
}