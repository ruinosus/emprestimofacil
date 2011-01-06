using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloEmprestimo.Constantes;

namespace SiteMVC.ModuloEmprestimo.Excecoes
{
    /// <summary>
    /// Classe EmprestimoNaoExcluidoExcecao
    /// </summary>
    public class EmprestimoNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public EmprestimoNaoExcluidoExcecao()
            : base(EmprestimoConstantes.EMPRESTIMO_NAOEXCLUIDO)
        { }
    }
}