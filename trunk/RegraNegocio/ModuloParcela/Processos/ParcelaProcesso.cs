
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Singleton;
using RegraNegocio.ModuloParcela.Repositorios;
using RegraNegocio.ModuloParcela.Processos;
using RegraNegocio.ModuloParcela.Fabricas;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloParcela.Excecoes;
namespace RegraNegocio.ModuloParcela.Processos
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

                resultado[0].Status = (int)Status.Inativo;
                this.Alterar(resultado[0]);
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