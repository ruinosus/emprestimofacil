
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloArea.Repositorios;
using SiteMVCTelerik.ModuloArea.Processos;
using SiteMVCTelerik.ModuloArea.Fabricas;
using SiteMVCTelerik.ModuloArea.Excecoes;

using SiteMVCTelerik.Models.ModuloBasico.VOs;
using SiteMVCTelerik.ModuloBasico;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloBasico.Enums;
namespace SiteMVCTelerik.ModuloArea.Processos
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