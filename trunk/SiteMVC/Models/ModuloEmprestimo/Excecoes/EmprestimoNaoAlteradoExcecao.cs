using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloEmprestimo.Constantes;

namespace SiteMVC.ModuloEmprestimo.Excecoes
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