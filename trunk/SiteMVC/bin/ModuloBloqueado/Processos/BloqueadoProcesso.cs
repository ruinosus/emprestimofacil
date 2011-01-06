using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloBasico.Singleton;
using SiteMVC.ModuloBloqueado.Repositorios;
using SiteMVC.ModuloBloqueado.Processos;
using SiteMVC.ModuloBloqueado.Fabricas;
using SiteMVC.ModuloBasico.Enums;
using SiteMVC.ModuloBloqueado.Excecoes;
using SiteMVC.Models.ModuloBasico.VOs;

namespace SiteMVC.ModuloBloqueado.Processos
{
    /// <summary>
    /// Classe BloqueadoProcesso
    /// </summary>
    public class BloqueadoProcesso : Singleton<BloqueadoProcesso>, IBloqueadoProcesso
    {
        #region Atributos
        private IBloqueadoRepositorio bloqueadoRepositorio = null;
        #endregion

        #region Construtor
        public BloqueadoProcesso()
        {
            bloqueadoRepositorio = BloqueadoFabrica.IBloqueadoInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(Bloqueado bloqueado)
        {
            this.bloqueadoRepositorio.Incluir(bloqueado);

        }

        public void Excluir(Bloqueado bloqueado)
        {

            try
            {
                if (bloqueado.ID == 0)
                    throw new BloqueadoNaoExcluidoExcecao();

                List<Bloqueado> resultado = bloqueadoRepositorio.Consultar(bloqueado, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new BloqueadoNaoExcluidoExcecao();

                this.Excluir(bloqueado);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.bloqueadoRepositorio.Excluir(bloqueado);
        }

        public void Alterar(Bloqueado bloqueado)
        {
            this.bloqueadoRepositorio.Alterar(bloqueado);
        }

        public List<Bloqueado> Consultar(Bloqueado bloqueado, TipoPesquisa tipoPesquisa)
        {
            List<Bloqueado> bloqueadoList = this.bloqueadoRepositorio.Consultar(bloqueado,tipoPesquisa);           

            return bloqueadoList;
        }

        public List<Bloqueado> Consultar()
        {
            List<Bloqueado> bloqueadoList = this.bloqueadoRepositorio.Consultar();

            return bloqueadoList;
        }

     
        public void Confirmar()
        {
            this.bloqueadoRepositorio.Confirmar();
        }

        #endregion
    }
}