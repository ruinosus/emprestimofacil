using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloEmprestimo.Constantes;

namespace SiteMVCTelerik.ModuloEmprestimo.Excecoes
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