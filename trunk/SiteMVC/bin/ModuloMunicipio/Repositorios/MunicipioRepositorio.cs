using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;

using SiteMVC.ModuloMunicipio.Excecoes;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloMunicipio.Repositorios
{
    public class MunicipioRepositorio : IMunicipioRepositorio
    {
        #region Atributos

        EmprestimoEntities db;

        #endregion

        #region Métodos da Interface

        public List<Municipio> Consultar()
        {
            return db.MunicipioSet.ToList();
        }

        public List<Municipio> Consultar(Municipio municipio, TipoPesquisa tipoPesquisa)
        {
            List<Municipio> resultado = Consultar();

            switch (tipoPesquisa)
            {
                #region Case E
                case TipoPesquisa.E:
                    {
                        if (municipio.ID != 0)
                        {

                            resultado = ((from c in resultado
                                          where
                                          c.ID == municipio.ID
                                          select c).ToList());

                            resultado = resultado.Distinct().ToList();
                        }


                        break;
                    }
                #endregion
                #region Case Ou
                case TipoPesquisa.Ou:
                    {
                        if (municipio.ID != 0)
                        {
                            resultado.AddRange((from c in Consultar()
                                                where
                                                c.ID == municipio.ID
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

        public void Incluir(Municipio municipio)
        {
            try
            {
                db.AddToMunicipioSet(municipio);
            }
            catch (Exception)
            {

                throw new MunicipioNaoIncluidoExcecao();
            }
        }

        public void Excluir(Municipio municipio)
        {
            try
            {
                Municipio municipioAux = new Municipio();
                municipioAux.ID = municipio.ID;


                List<Municipio> resultado = this.Consultar(municipioAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new MunicipioNaoExcluidoExcecao();

                municipioAux = resultado[0];

                db.DeleteObject(municipioAux);

            }
            catch (Exception)
            {

                throw new MunicipioNaoExcluidoExcecao();
            }
        }

        public void Alterar(Municipio municipio)
        {
            try
            {
                Municipio municipioAux = new Municipio();
                municipioAux.ID = municipio.ID;


                List<Municipio> resultado = this.Consultar(municipioAux, TipoPesquisa.E);

                if (resultado == null || resultado.Count == 0)
                    throw new MunicipioNaoAlteradoExcecao();
                municipioAux = resultado[0];
                municipioAux.ID = municipio.ID;
                municipioAux.nome = municipio.nome;
                municipioAux.uf = municipio.uf;
                

                Confirmar();
            }
            catch (Exception)
            {

                throw new MunicipioNaoAlteradoExcecao();
            }
        }

        public void Confirmar()
        {
            db.SaveChanges();
        }

        #endregion

        #region Construtor
        public MunicipioRepositorio()
        {
          
            db = new EmprestimoEntities();

        }
        #endregion


    }
}