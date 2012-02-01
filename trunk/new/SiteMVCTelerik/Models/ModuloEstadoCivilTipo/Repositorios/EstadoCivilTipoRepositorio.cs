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

        emprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<EstadoCivilTipo> Consultar()
        {
            return db.estadociviltipo.ToList();
        }

        public List<EstadoCivilTipo> Consultar(EstadoCivilTipo estadoCivilTipo, TipoPesquisa tipoPesquisa)
        {
            List<EstadoCivilTipo> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (estadoCivilTipo.id != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.id == estadoCivilTipo.id
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (estadoCivilTipo.id != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.id == estadoCivilTipo.id
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
                db.AddToestadociviltipo(estadoCivilTipo);
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
                estadoCivilTipoAux.id = estadoCivilTipo.id;


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
                estadoCivilTipoAux.id = estadoCivilTipo.id;


                List<EstadoCivilTipo> resultado = this.Consultar(estadoCivilTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new EstadoCivilTipoNaoAlteradoExcecao();

                estadoCivilTipoAux.descricao = estadoCivilTipo.descricao;
                estadoCivilTipoAux.id = estadoCivilTipo.id;
             
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
     
            db = new emprestimoEntities();

        }
        #endregion


    }
}