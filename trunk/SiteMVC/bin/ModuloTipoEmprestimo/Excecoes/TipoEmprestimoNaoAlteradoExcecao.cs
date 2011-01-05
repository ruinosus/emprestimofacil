using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloTipoEmprestimo.Constantes;

namespace SiteMVC.ModuloTipoEmprestimo.Excecoes
{
    /// <summary>
    /// Classe TipoEmprestimoNaoAlteradoExcecao
    /// </summary>
    public class TipoEmprestimoNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public TipoEmprestimoNaoAlteradoExcecao()
            : base(TipoEmprestimoConstantes.TIPO_EMPRESTIMO_NAOALTERADO)
        { }
    }
}