using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloMunicipio.Repositorios;
using SiteMVC.ModuloMunicipio.Processos;
using SiteMVC.ModuloMunicipio.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloMunicipio.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloMunicipio.Processos
{
    /// <summary>
    /// Classe MunicipioProcesso
    /// </summary>
    public class MunicipioProcesso : Singleton<MunicipioProcesso>, IMunicipioProcesso
    {
        #region Atributos
        private IMunicipioRepositorio municipioRepositorio = null;
        #endregion

        #region Construtor
        public MunicipioProcesso()
        {
            municipioRepositorio = MunicipioFabrica.IMunicipioInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(Municipio municipio)
        {
            this.municipioRepositorio.Incluir(municipio);

        }

        public void Excluir(Municipio municipio)
        {

            try
            {
                if (municipio.ID == 0)
                    throw new MunicipioNaoExcluidoExcecao();

                List<Municipio> resultado = municipioRepositorio.Consultar(municipio, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new MunicipioNaoExcluidoExcecao();
                this.municipioRepositorio.Excluir(municipio);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.municipioRepositorio.Excluir(municipio);
        }

        public void Alterar(Municipio municipio)
        {
            this.municipioRepositorio.Alterar(municipio);
        }

        public List<Municipio> Consultar(Municipio municipio, TipoPesquisa tipoPesquisa)
        {
            List<Municipio> municipioList = this.municipioRepositorio.Consultar(municipio,tipoPesquisa);           

            return municipioList;
        }

        public List<Municipio> Consultar()
        {
            List<Municipio> municipioList = this.municipioRepositorio.Consultar();

            return municipioList;
        }

     
        public void Confirmar()
        {
            this.municipioRepositorio.Confirmar();
        }

        #endregion
    }
}