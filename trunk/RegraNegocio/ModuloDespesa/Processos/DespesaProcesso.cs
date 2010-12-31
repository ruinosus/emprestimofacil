
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloBasico.Singleton;
using Negocios.ModuloDespesa.Repositorios;
using Negocios.ModuloDespesa.Processos;
using Negocios.ModuloDespesa.Fabricas;
using Negocios.ModuloBasico.Enums;
using Negocios.ModuloDespesa.Excecoes;
namespace Negocios.ModuloDespesa.Processos
{
    /// <summary>
    /// Classe DespesaProcesso
    /// </summary>
    public class DespesaProcesso : Singleton<DespesaProcesso>, IDespesaProcesso
    {
        #region Atributos
        private IDespesaRepositorio DespesaRepositorio = null;
        #endregion

        #region Construtor
        public DespesaProcesso()
        {
            DespesaRepositorio = DespesaFabrica.IDespesaInstance;
        }

        #endregion


        #region M�todos da Interface

        public void Incluir(Despesa Despesa)
        {
            this.DespesaRepositorio.Incluir(Despesa);

        }

        public void Excluir(Despesa Despesa)
        {
            try
            {
                if (Despesa.ID == 0)
                    throw new DespesaNaoExcluidaExcecao();

                List<Despesa> resultado = DespesaRepositorio.Consultar(Despesa, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new DespesaNaoExcluidaExcecao();

                resultado[0].Status = (int)Status.Inativo;
                this.Alterar(resultado[0]);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.DespesaRepositorio.Excluir(Despesa);
        }

        public void Alterar(Despesa Despesa)
        {
            this.DespesaRepositorio.Alterar(Despesa);
        }

        public List<Despesa> Consultar(Despesa Despesa, TipoPesquisa tipoPesquisa)
        {
            List<Despesa> DespesaList = this.DespesaRepositorio.Consultar(Despesa,tipoPesquisa);           

            return DespesaList;
        }

        public List<Despesa> Consultar()
        {
            List<Despesa> DespesaList = this.DespesaRepositorio.Consultar();

            return DespesaList;
        }

        public void Confirmar()
        {
            this.DespesaRepositorio.Confirmar();
        }

        #endregion
    }
}