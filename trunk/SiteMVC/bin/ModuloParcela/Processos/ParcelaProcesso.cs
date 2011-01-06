
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloParcela.Repositorios;
using SiteMVC.ModuloParcela.Processos;
using SiteMVC.ModuloParcela.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloParcela.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;
namespace SiteMVC.ModuloParcela.Processos
{
    /// <summary>
    /// Classe ParcelaProcesso
    /// </summary>
    public class ParcelaProcesso : Singleton<ParcelaProcesso>, IParcelaProcesso
    {
        #region Atributos
        private IParcelaRepositorio parcelaRepositorio = null;
        #endregion

        #region Construtor
        public ParcelaProcesso()
        {
            parcelaRepositorio = ParcelaFabrica.IParcelaInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(Parcela parcela)
        {
            this.parcelaRepositorio.Incluir(parcela);

        }

        public void Excluir(Parcela parcela)
        {
            try
            {
                if (parcela.ID == 0)
                    throw new ParcelaNaoExcluidaExcecao();

                List<Parcela> resultado = parcelaRepositorio.Consultar(parcela, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new ParcelaNaoExcluidaExcecao();
                this.parcelaRepositorio.Excluir(parcela);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.parcelaRepositorio.Excluir(parcela);
        }

        public void Alterar(Parcela parcela)
        {
            this.parcelaRepositorio.Alterar(parcela);
        }

        public List<Parcela> Consultar(Parcela parcela, TipoPesquisa tipoPesquisa)
        {
            List<Parcela> parcelaList = this.parcelaRepositorio.Consultar(parcela,tipoPesquisa);           

            return parcelaList;
        }

        public List<Parcela> Consultar()
        {
            List<Parcela> parcelaList = this.parcelaRepositorio.Consultar();

            return parcelaList;
        }

        public void Confirmar()
        {
            this.parcelaRepositorio.Confirmar();
        }

        #endregion
    }
}