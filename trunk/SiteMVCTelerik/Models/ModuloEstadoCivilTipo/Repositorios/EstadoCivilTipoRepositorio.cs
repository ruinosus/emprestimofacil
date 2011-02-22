using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;

using SiteMVCTelerik.ModuloEstadoCivilTipo.Excecoes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloEstadoCivilTipo.Repositorios
{
    public class EstadoCivilTipoRepositorio : IEstadoCivilTipoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<EstadoCivilTipo> Consultar()
        {
            return db.EstadoCivilTipoSet.ToList();
        }

        public List<EstadoCivilTipo> Consultar(EstadoCivilTipo estadoCivilTipo, TipoPesquisa tipoPesquisa)
        {
            List<EstadoCivilTipo> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (estadoCivilTipo.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == estadoCivilTipo.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (estadoCivilTipo.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == estadoCivilTipo.ID
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

        public void Incluir(EstadoCivilTipo estadoCivilTipo)
        {
            try
            {
                db.AddToEstadoCivilTipoSet(estadoCivilTipo);
            }
            catch (Exception)
            {

                throw new EstadoCivilTipoNaoIncluidoExcecao();
            }
        }

        public void Excluir(EstadoCivilTipo estadoCivilTipo)
        {
            try
            {
                EstadoCivilTipo estadoCivilTipoAux = new EstadoCivilTipo();
                estadoCivilTipoAux.ID = estadoCivilTipo.ID;


                List<EstadoCivilTipo> resultado = this.Consultar(estadoCivilTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EstadoCivilTipoNaoExcluidoExcecao();

                estadoCivilTipoAux = resultado[0];

                db.DeleteObject(estadoCivilTipoAux);

            }
            catch (Exception)
            {

                throw new EstadoCivilTipoNaoExcluidoExcecao();
            }
        }

        public void Alterar(EstadoCivilTipo estadoCivilTipo)
        {
            try
            {
                EstadoCivilTipo estadoCivilTipoAux = new EstadoCivilTipo();
                estadoCivilTipoAux.ID = estadoCivilTipo.ID;


                List<EstadoCivilTipo> resultado = this.Consultar(estadoCivilTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EstadoCivilTipoNaoAlteradoExcecao();

                estadoCivilTipoAux.descricao = estadoCivilTipo.descricao;
                estadoCivilTipoAux.ID = estadoCivilTipo.ID;
             
                estadoCivilTipoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new EstadoCivilTipoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public EstadoCivilTipoRepositorio()
        {
     
            db = new EmprestimoEntities();

        }
        #endregion


    }
}