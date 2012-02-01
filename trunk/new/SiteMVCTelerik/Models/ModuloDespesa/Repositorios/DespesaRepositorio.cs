using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;

using SiteMVCTelerik.ModuloDespesa.Excecoes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloDespesa.Repositorios
{
    public class DespesaRepositorio : IDespesaRepositorio
    {
        #region Atributos

        emprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Despesa> Consultar()
        {
            return db.despesa.ToList();
        }

        public List<Despesa> Consultar(Despesa despesa, TipoPesquisa tipoPesquisa)
        {
            List<Despesa> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (despesa.id != 0)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.id == despesa.id
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
                        if (despesa.id != 0)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.id == despesa.id
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
                db.AddTodespesa(despesa);
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
                despesaAux.id = despesa.id;

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
                despesaAux.id = despesa.id;

                List<Despesa> resultado = this.Consultar(despesaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new DespesaNaoAlteradaExcecao();

                despesaAux = resultado[0];
                despesaAux.data = despesa.data;
                despesaAux.despesatipo_id = despesa.despesatipo_id;
                despesaAux.id = despesa.id;
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
            db = new emprestimoEntities();
        }
        #endregion


    }
}