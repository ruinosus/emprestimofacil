
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloArea.Repositorios;
using Negocios.ModuloArea.Processos;
using Negocios.ModuloArea.Fabricas;
using Negocios.ModuloArea.Excecoes;
using ModuloBasico;
using RegraNegocio.ModuloBasico.VOs;
using RegraNegocio.ModuloBasico;
namespace Negocios.ModuloArea.Processos
{
    /// <summary>
    /// Classe AreaProcesso
    /// </summary>
    public class AreaProcesso : Singleton<AreaProcesso>, IAreaProcesso
    {
        #region Atributos
        private IAreaRepositorio areaRepositorio = null;
        #endregion

        #region Construtor
        public AreaProcesso()
        {
            areaRepositorio = AreaFabrica.IAreaInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(Area area)
        {
            this.areaRepositorio.Incluir(area);

        }

        public void Excluir(Area area)
        {
            try
            {
                if (area.ID == 0)
                    throw new AreaNaoExcluidaExcecao();

       //         List<Area> resultado = areaRepositorio.Consultar(area, TipoPesquisa.E);
                this.areaRepositorio.Excluir(area);
                //if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                //    throw new AreaNaoExcluidaExcecao();

                //resultado[0].Status = (int)Status.Inativo;
                //this.Alterar(resultado[0]);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.areaRepositorio.Excluir(area);
        }

        public void Alterar(Area area)
        {
            this.areaRepositorio.Alterar(area);
        }

        public List<Area> Consultar(Area area, TipoPesquisa tipoPesquisa)
        {
            List<Area> areaList = this.areaRepositorio.Consultar(area,tipoPesquisa);           

            return areaList;
        }

        public List<Area> Consultar()
        {
            List<Area> areaList = this.areaRepositorio.Consultar();

            return areaList;
        }

        public void Confirmar()
        {
            this.areaRepositorio.Confirmar();
        }

        #endregion
    }
}