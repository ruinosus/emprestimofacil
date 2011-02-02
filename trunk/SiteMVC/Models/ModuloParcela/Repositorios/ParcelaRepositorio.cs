using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;

using SiteMVC.ModuloParcela.Excecoes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloParcela.Repositorios
{
    public class ParcelaRepositorio : IParcelaRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Parcela> Consultar()
        {
            return db.ParcelaSet.ToList();
        }

        public List<Parcela> Consultar(Parcela parcela, TipoPesquisa tipoPesquisa)
        {
            List<Parcela> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (parcela.ID != 0)
                        {

                            resultado = ((from t in resultado
                                          where
                                          t.ID == parcela.ID
                                          select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }
                        else
                        {

                            if (parcela.emprestimo_id != 0)
                            {

                                resultado = ((from t in resultado
                                              where
                                              t.emprestimo_id == parcela.emprestimo_id
                                              select t).ToList());

                                resultado = resultado.Distinct().ToList();
                            }

                            if (ClasseAuxiliar.AreaSelecionada!= null)
                            {

                                resultado = ((from t in resultado
                                              where
                                              t.emprestimo.area_id == ClasseAuxiliar.AreaSelecionada.ID
                                              select t).ToList());

                                resultado = resultado.Distinct().ToList();
                            }

                            if (parcela.statusparcela_id != 0)
                            {

                                resultado = ((from t in resultado
                                              where
                                              t.statusparcela_id == parcela.statusparcela_id
                                              select t).ToList());

                                resultado = resultado.Distinct().ToList();
                            }

                            if (parcela.data_pagamento.HasValue)
                            {

                                resultado = ((from t in resultado
                                              where
                                              t.data_pagamento == parcela.data_pagamento
                                              select t).ToList());

                                resultado = resultado.Distinct().ToList();
                            }

                            if (!string.IsNullOrEmpty(parcela.visualizada))
                            {

                                resultado = ((from t in resultado
                                              where
                                             t.visualizada != null && t.visualizada.Equals(parcela.visualizada)
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
                        if (parcela.ID != 0)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.ID == parcela.ID
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (parcela.statusparcela_id != 0)
                        {

                            resultado.AddRange((from t in resultado
                                                where
                                                t.statusparcela_id == parcela.statusparcela_id
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (parcela.emprestimo_id != 0)
                        {

                            resultado.AddRange((from t in Consultar()
                                                where
                                                t.emprestimo_id == parcela.emprestimo_id
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (parcela.data_pagamento.HasValue)
                        {

                            resultado.AddRange((from t in resultado
                                                where
                                                t.data_pagamento == parcela.data_pagamento
                                                select t).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        if (!string.IsNullOrEmpty(parcela.visualizada))
                        {

                            resultado.AddRange((from t in resultado
                                                where
                                                 t.visualizada != null && t.visualizada.Equals(parcela.visualizada)
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

        public void Incluir(Parcela parcela)
        {
            try
            {
                db.AddToParcelaSet(parcela);
            }
            catch (Exception)
            {

                throw new ParcelaNaoIncluidaExcecao();
            }
        }

        public void Excluir(Parcela parcela)
        {
            try
            {
                Parcela parcelaAux = new Parcela();
                parcelaAux.ID = parcela.ID;

                List<Parcela> resultado = this.Consultar(parcelaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new ParcelaNaoExcluidaExcecao();

                parcelaAux = resultado[0];

                db.DeleteObject(parcelaAux);
            }
            catch (Exception)
            {

                throw new ParcelaNaoExcluidaExcecao();
            }
        }

        public void Alterar(Parcela parcela)
        {
            try
            {
                Parcela parcelaAux = new Parcela();
                parcelaAux.ID = parcela.ID;

                List<Parcela> resultado = this.Consultar(parcelaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new ParcelaNaoAlteradaExcecao();

                parcelaAux = resultado[0];
                parcelaAux.data_pagamento = parcela.data_pagamento;
                parcelaAux.data_vencimento = parcela.data_vencimento;
                parcelaAux.emprestimo_id = parcela.emprestimo_id;
                parcelaAux.ID = parcela.ID;
                parcelaAux.juros_atraso = parcela.juros_atraso;
                parcelaAux.multa_atraso = parcela.multa_atraso;
                parcelaAux.observacoes = parcela.observacoes;
                parcelaAux.sequencial = parcela.sequencial;
                parcelaAux.statusparcela_id = parcela.statusparcela_id;
                parcelaAux.valor = parcela.valor;
                parcelaAux.valor_pago = parcela.valor_pago;
                parcelaAux.visualizada = parcela.visualizada;




                Confirmar();
            }
            catch (Exception)
            {

                throw new ParcelaNaoAlteradaExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public ParcelaRepositorio()
        {
            db = new EmprestimoEntities();
        }
        #endregion


    }
}