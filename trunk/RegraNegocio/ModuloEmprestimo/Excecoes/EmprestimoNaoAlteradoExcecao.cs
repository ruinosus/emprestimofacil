using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloEmprestimo.Constantes;

namespace Negocios.ModuloEmprestimo.Excecoes
{
    /// <summary>
    /// Classe EmprestimoNaoAlteradoExcecao
    /// </summary>
    public class EmprestimoNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public EmprestimoNaoAlteradoExcecao()
            : base(EmprestimoConstantes.EMPRESTIMO_NAOALTERADO)
        { }
    }
}