using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloEmprestimo.Constantes;

namespace Negocios.ModuloEmprestimo.Excecoes
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