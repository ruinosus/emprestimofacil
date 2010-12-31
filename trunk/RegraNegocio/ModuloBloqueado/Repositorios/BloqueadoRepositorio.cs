using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBloqueado.Excecoes;
using RegraNegocio.ModuloBasico;
using RegraNegocio.ModuloBasico.VOs;
using RegraNegocio.ModuloBasico.Enums;


namespace RegraNegocio.ModuloBloqueado.Repositorios
{
    public class BloqueadoRepositorio : IBloqueadoRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Bloqueado> Consultar()
        {
            return db.BloqueadoSet.ToList();
        }

        public List<Bloqueado> Consultar(Bloqueado bloqueado, TipoPesquisa tipoPesquisa)
        {
            List<Bloqueado> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (bloqueado.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == bloqueado.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }

                       

                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (bloqueado.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == bloqueado.ID
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

        public void Incluir(Bloqueado bloqueado)
        {
            try
            {
                db.AddToBloqueadoSet(bloqueado);
            }
            catch (Exception)
            {

                throw new BloqueadoNaoIncluidoExcecao();
            }
        }

        public void Excluir(Bloqueado bloqueado)
        {
            try
            {
                Bloqueado bloqueadoAux = new Bloqueado();
                bloqueadoAux.ID = bloqueado.ID;


                List<Bloqueado> resultado = this.Consultar(bloqueadoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new BloqueadoNaoExcluidoExcecao();

                bloqueadoAux = resultado[0];

                db.DeleteObject(bloqueadoAux);

            }
            catch (Exception)
            {

                throw new BloqueadoNaoExcluidoExcecao();
            }
        }

        public void Alterar(Bloqueado bloqueado)
        {
            try
            {
                Bloqueado bloqueadoAux = new Bloqueado();
                bloqueadoAux.ID = bloqueado.ID;


                List<Bloqueado> resultado = this.Consultar(bloqueadoAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new BloqueadoNaoAlteradoExcecao();

                bloqueadoAux.cliente_id = bloqueado.cliente_id;
                bloqueadoAux.motivo = bloqueado.motivo;
                bloqueadoAux.timeCreated = bloqueado.timeCreated;
                bloqueadoAux.timeUpdated = bloqueado.timeUpdated;
                bloqueadoAux.usuario_id = bloqueado.usuario_id;
                bloqueadoAux.ID = bloqueado.ID;
             

                bloqueadoAux = resultado[0];

                Confirmar();
            }
            catch (Exception)
            {

                throw new BloqueadoNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public BloqueadoRepositorio()
        {
            db = new EmprestimoEntities();

        }
        #endregion


    }
}