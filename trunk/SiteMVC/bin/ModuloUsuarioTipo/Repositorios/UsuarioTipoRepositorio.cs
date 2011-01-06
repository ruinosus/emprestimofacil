using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloUsuarioTipo.Excecoes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloUsuarioTipo.Repositorios
{
    public class UsuarioTipoRepositorio : IUsuarioTipoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<UsuarioTipo> Consultar()
        {
            return db.UsuarioTipoSet.ToList();
        }

        public List<UsuarioTipo> Consultar(UsuarioTipo usuarioTipo, TipoPesquisa tipoPesquisa)
        {
            List<UsuarioTipo> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (usuarioTipo.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == usuarioTipo.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                      
                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (usuarioTipo.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == usuarioTipo.ID
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

        public void Incluir(UsuarioTipo usuarioTipo)
        {
            try
            {
                db.AddToUsuarioTipoSet(usuarioTipo);
            }
            catch (Exception)
            {

                throw new UsuarioTipoNaoIncluidoExcecao();
            }
        }

        public void Excluir(UsuarioTipo usuarioTipo)
        {
            try
            {
                UsuarioTipo usuarioTipoAux = new UsuarioTipo();
                usuarioTipoAux.ID = usuarioTipo.ID;


                List<UsuarioTipo> resultado = this.Consultar(usuarioTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new UsuarioTipoNaoExcluidoExcecao();

                usuarioTipoAux = resultado[0];

                db.DeleteObject(usuarioTipoAux);

            }
            catch (Exception)
            {

                throw new UsuarioTipoNaoExcluidoExcecao();
            }
        }

        public void Alterar(UsuarioTipo usuarioTipo)
        {
            try
            {
                UsuarioTipo usuarioTipoAux = new UsuarioTipo();
                usuarioTipoAux.ID = usuarioTipo.ID;


                List<UsuarioTipo> resultado = this.Consultar(usuarioTipoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new UsuarioTipoNaoAlteradoExcecao();

                usuarioTipoAux.descricao = usuarioTipo.descricao;
                usuarioTipoAux.ID = usuarioTipo.ID;

                usuarioTipoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new UsuarioTipoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public UsuarioTipoRepositorio()
        {

            db = new EmprestimoEntities();

        }
        #endregion


    }
}