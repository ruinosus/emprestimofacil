using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Singleton;
using RegraNegocio.ModuloMunicipio.Repositorios;
using RegraNegocio.ModuloMunicipio.Processos;
using RegraNegocio.ModuloMunicipio.Fabricas;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloMunicipio.Excecoes;

namespace RegraNegocio.ModuloMunicipio.Processos
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

                resultado[0].Status = (int)Status.Inativo;
                this.Alterar(resultado[0]);
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