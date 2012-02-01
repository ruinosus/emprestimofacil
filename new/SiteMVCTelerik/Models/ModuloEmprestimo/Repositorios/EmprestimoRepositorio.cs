using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;

using SiteMVCTelerik.ModuloEmprestimo.Excecoes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloEmprestimo.Repositorios
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        #region Atributos

        emprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Emprestimo> Consultar()
        {
            return db.emprestimo.ToList();
        }

        public List<Emprestimo> Consultar(Emprestimo emprestimo, TipoPesquisa tipoPesquisa)
        {
            List<Emprestimo> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (emprestimo.id != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.id == emprestimo.id
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }
                        else
                        {

                            if (emprestimo.cliente_id != 0)
                            {

                                resultado = ((from c in resultado
                                              where
                                              c.cliente_id == emprestimo.cliente_id
                                              select c).ToList());

                                resultado = resultado.Distinct().ToList();
                            }

                            if (emprestimo.area_id != 0)
                            {

                                resultado = ((from c in resultado
                                              where
                                              c.area_id == emprestimo.area_id
                                              select c).ToList());

                                resultado = resultado.Distinct().ToList();
                            }

                            if (emprestimo.data_emprestimo !=default(DateTime))
                            {

                                resultado = ((from c in resultado
                                              where
                                              c.data_emprestimo.Date.Equals(emprestimo.data_emprestimo.Date)
                                              select c).ToList());

                                resultado = resultado.Distinct().ToList();
                            }

                        }
                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (emprestimo.id != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.id == emprestimo.id
                                                select c).ToList());
                            resultado = resultado.Distinct().ToList();
                        }

                        if (emprestimo.cliente_id != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.cliente_id == emprestimo.cliente_id
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

        public void Incluir(Emprestimo emprestimo)
        {
            try
            {
                db.AddToemprestimo(emprestimo);
            }
            catch (Exception)
            {

                throw new EmprestimoNaoIncluidoExcecao();
            }
        }

        public void Excluir(Emprestimo emprestimo)
        {
            try
            {
                Emprestimo emprestimoAux = new Emprestimo();
                emprestimoAux.id = emprestimo.id;


                List<Emprestimo> resultado = this.Consultar(emprestimoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EmprestimoNaoExcluidoExcecao();

                emprestimoAux = resultado[0];

                db.DeleteObject(emprestimoAux);

            }
            catch (Exception)
            {

                throw new EmprestimoNaoExcluidoExcecao();
            }
        }

        public void Alterar(Emprestimo emprestimo)
        {
            try
            {
                Emprestimo emprestimoAux = new Emprestimo();
                emprestimoAux.id = emprestimo.id;


                List<Emprestimo> resultado = this.Consultar(emprestimoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EmprestimoNaoAlteradoExcecao();

                emprestimoAux.cliente_id = emprestimo.cliente_id;
                emprestimoAux.data_emprestimo = emprestimo.data_emprestimo;
                emprestimoAux.id = emprestimo.id;
                emprestimoAux.juros = emprestimo.juros;
                emprestimoAux.prazospagamento_id = emprestimo.prazospagamento_id;
                emprestimoAux.qtde_parcelas = emprestimo.qtde_parcelas;
                emprestimoAux.tipoemprestimo_id = emprestimo.tipoemprestimo_id;
                emprestimoAux.usuario_id = emprestimo.usuario_id;
                emprestimoAux.valor = emprestimo.valor;

                emprestimoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new EmprestimoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public EmprestimoRepositorio()
        {
           
            db = new emprestimoEntities();

        }
        #endregion


    }
}