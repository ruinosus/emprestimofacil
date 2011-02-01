using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloUsuarioArea.Excecoes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;


namespace SiteMVC.ModuloUsuarioArea.Repositorios
{
    public class UsuarioAreaRepositorio : IUsuarioAreaRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<UsuarioArea> Consultar()
        {
            return db.UsuarioAreaSet.ToList();
        }

        public List<UsuarioArea> Consultar(UsuarioArea usuarioArea, TipoPesquisa tipoPesquisa)
        {
            List<UsuarioArea> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (usuarioArea.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == usuarioArea.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }
                        else if (usuarioArea.usuario_id != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.usuario_id == usuarioArea.usuario_id
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (usuarioArea.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == usuarioArea.ID
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

        public void Incluir(UsuarioArea usuarioArea)
        {
            try
            {
                db.AddToUsuarioAreaSet(usuarioArea);
            }
            catch (Exception)
            {

                throw new UsuarioAreaNaoIncluidoExcecao();
            }
        }

        public void Excluir(UsuarioArea usuarioArea)
        {
            try
            {
                UsuarioArea usuarioAreaAux = new UsuarioArea();
                usuarioAreaAux.ID = usuarioArea.ID;


                List<UsuarioArea> resultado = this.Consultar(usuarioAreaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new UsuarioAreaNaoExcluidoExcecao();

                usuarioAreaAux = resultado[0];

                db.DeleteObject(usuarioAreaAux);

            }
            catch (Exception)
            {

                throw new UsuarioAreaNaoExcluidoExcecao();
            }
        }

        public void Alterar(UsuarioArea usuarioArea)
        {
            try
            {
                UsuarioArea usuarioAreaAux = new UsuarioArea();
                usuarioAreaAux.ID = usuarioArea.ID;


                List<UsuarioArea> resultado = this.Consultar(usuarioAreaAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new UsuarioAreaNaoAlteradoExcecao();

                usuarioAreaAux = resultado[0];

                usuarioAreaAux.area_id = usuarioArea.area_id;
                usuarioAreaAux.usuario_id = usuarioArea.usuario_id;



                Confirmar();
            }
            catch (Exception)
            {

                throw new UsuarioAreaNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public UsuarioAreaRepositorio()
        {

            db = new EmprestimoEntities();

        }
        #endregion


    }
}