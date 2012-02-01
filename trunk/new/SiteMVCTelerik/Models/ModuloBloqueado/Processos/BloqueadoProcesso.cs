using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloBloqueado.Repositorios;
using SiteMVCTelerik.ModuloBloqueado.Processos;
using SiteMVCTelerik.ModuloBloqueado.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloBloqueado.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;

namespace SiteMVCTelerik.ModuloBloqueado.Processos
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


        #region M�todos da Interface

        public void Incluir(Bloqueado bloqueado)
        {
            this.bloqueadoRepositorio.Incluir(bloqueado);

        }

        public void Excluir(Bloqueado bloqueado)
        {

            try
            {
                if (bloqueado.id == 0)
                    throw new BloqueadoNaoExcluidoExcecao();

                List<Bloqueado> resultado = bloqueadoRepositorio.Consultar(bloqueado, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new BloqueadoNaoExcluidoExcecao();

                this.bloqueadoRepositorio.Excluir(bloqueado);
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