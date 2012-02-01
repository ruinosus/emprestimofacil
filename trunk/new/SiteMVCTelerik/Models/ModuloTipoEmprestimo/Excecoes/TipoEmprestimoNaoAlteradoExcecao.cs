using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloTipoEmprestimo.Constantes;

namespace SiteMVCTelerik.ModuloTipoEmprestimo.Excecoes
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