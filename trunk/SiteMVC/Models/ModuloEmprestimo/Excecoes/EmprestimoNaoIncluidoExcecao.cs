using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloEmprestimo.Constantes;

namespace SiteMVC.ModuloEmprestimo.Excecoes
{
    /// <summary>
    /// Classe EmprestimoNaoIncluidoExcecao
    /// </summary>
    public class EmprestimoNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public EmprestimoNaoIncluidoExcecao()
            : base(EmprestimoConstantes.EMPRESTIMO_NAOINCLUIDO)
        { }
    }
}