
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBasico.Singleton;
using SiteMVCTelerik.ModuloEscolaridade.Repositorios;
using SiteMVCTelerik.ModuloEscolaridade.Processos;
using SiteMVCTelerik.ModuloEscolaridade.Fabricas;
using SiteMVCTelerik.ModuloBasico.Enums;
using SiteMVCTelerik.ModuloEscolaridade.Excecoes;
using SiteMVCTelerik.Models.ModuloBasico.VOs;
namespace SiteMVCTelerik.ModuloEscolaridade.Processos
{
    /// <summary>
    /// Classe EscolaridadeProcesso
    /// </summary>
    public class EscolaridadeProcesso : Singleton<EscolaridadeProcesso>, IEscolaridadeProcesso
    {
        #region Atributos
        private IEscolaridadeRepositorio escolaridadeRepositorio = null;
        #endregion

        #region Construtor
        public EscolaridadeProcesso()
        {
            escolaridadeRepositorio = EscolaridadeFabrica.IEscolaridadeInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(Escolaridade escolaridade)
        {
            this.escolaridadeRepositorio.Incluir(escolaridade);

        }

        public void Excluir(Escolaridade escolaridade)
        {
            try
            {
                if (escolaridade.id == 0)
                    throw new EscolaridadeNaoExcluidaExcecao();

                List<Escolaridade> resultado = escolaridadeRepositorio.Consultar(escolaridade, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new EscolaridadeNaoExcluidaExcecao();

                this.escolaridadeRepositorio.Excluir(escolaridade);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.escolaridadeRepositorio.Excluir(escolaridade);
        }

        public void Alterar(Escolaridade escolaridade)
        {
            this.escolaridadeRepositorio.Alterar(escolaridade);
        }

        public List<Escolaridade> Consultar(Escolaridade escolaridade, TipoPesquisa tipoPesquisa)
        {
            List<Escolaridade> escolaridadeList = this.escolaridadeRepositorio.Consultar(escolaridade,tipoPesquisa);           

            return escolaridadeList;
        }

        public List<Escolaridade> Consultar()
        {
            List<Escolaridade> escolaridadeList = this.escolaridadeRepositorio.Consultar();

            return escolaridadeList;
        }

        public void Confirmar()
        {
            this.escolaridadeRepositorio.Confirmar();
        }

        #endregion
    }
}