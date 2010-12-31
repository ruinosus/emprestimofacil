using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBasico.Singleton;
using RegraNegocio.ModuloEmprestimo.Repositorios;
using RegraNegocio.ModuloEmprestimo.Processos;
using RegraNegocio.ModuloEmprestimo.Fabricas;
using RegraNegocio.ModuloBasico.Enums;
using RegraNegocio.ModuloEmprestimo.Excecoes;
using RegraNegocio.ModuloBasico.VOs;

namespace RegraNegocio.ModuloEmprestimo.Processos
{
    /// <summary>
    /// Classe EmprestimoProcesso
    /// </summary>
    public class EmprestimoProcesso : Singleton<EmprestimoProcesso>, IEmprestimoProcesso
    {
        #region Atributos
        private IEmprestimoRepositorio emprestimoRepositorio = null;
        #endregion

        #region Construtor
        public EmprestimoProcesso()
        {
            emprestimoRepositorio = EmprestimoFabrica.IEmprestimoInstance;
        }

        #endregion


        #region Métodos da Interface

        public void Incluir(Emprestimo emprestimo)
        {
            this.emprestimoRepositorio.Incluir(emprestimo);

        }

        public void Excluir(Emprestimo emprestimo)
        {

            try
            {
                if (emprestimo.ID == 0)
                    throw new EmprestimoNaoExcluidoExcecao();

                List<Emprestimo> resultado = emprestimoRepositorio.Consultar(emprestimo, TipoPesquisa.E);

                if (resultado == null || resultado.Count <= 0 || resultado.Count > 1)
                    throw new EmprestimoNaoExcluidoExcecao();
                this.Excluir(emprestimo);
            }
            catch (Exception e)
            {

                throw e;
            }
            //this.emprestimoRepositorio.Excluir(emprestimo);
        }

        public void Alterar(Emprestimo emprestimo)
        {
            this.emprestimoRepositorio.Alterar(emprestimo);
        }

        public List<Emprestimo> Consultar(Emprestimo emprestimo, TipoPesquisa tipoPesquisa)
        {
            List<Emprestimo> emprestimoList = this.emprestimoRepositorio.Consultar(emprestimo,tipoPesquisa);           

            return emprestimoList;
        }

        public List<Emprestimo> Consultar()
        {
            List<Emprestimo> emprestimoList = this.emprestimoRepositorio.Consultar();

            return emprestimoList;
        }

     
        public void Confirmar()
        {
            this.emprestimoRepositorio.Confirmar();
        }

        #endregion
    }
}