using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloEmprestimo.Constantes;

namespace SiteMVCTelerik.ModuloEmprestimo.Excecoes
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