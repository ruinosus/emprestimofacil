using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloUsuarioArea.Excecoes;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.Models.ModuloBasico.VOs;


namespace SiteMVCTelerik.ModuloUsuarioArea.Repositorios
{
    public class UsuarioAreaRepositorio : IUsuarioAreaRepositorio
    {
        #region Atributos

        emprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<UsuarioArea> Consultar()
        {
            return db.usuarioarea.ToList();
        }

        public List<UsuarioArea> Consultar(UsuarioArea usuarioArea, TipoPesquisa tipoPesquisa)
        {
            List<UsuarioArea> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (usuarioArea.id != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.id == usuarioArea.id
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
                        if (usuarioArea.id != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.id == usuarioArea.id
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
                db.AddTousuarioarea(usuarioArea);
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
                usuarioAreaAux.id = usuarioArea.id;


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
                usuarioAreaAux.id = usuarioArea.id;


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

            db = new emprestimoEntities();

        }
        #endregion


    }
}