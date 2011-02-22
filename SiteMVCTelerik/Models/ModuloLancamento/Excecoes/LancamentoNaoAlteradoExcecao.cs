using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloLancamento.Constantes;

namespace SiteMVCTelerik.ModuloLancamento.Excecoes
{
    /// <summary>
    /// Classe LancamentoNaoAlteradoExcecao
    /// </summary>
    public class LancamentoNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public LancamentoNaoAlteradoExcecao()
            : base(LancamentoConstantes.LANCAMENTO_NAOALTERADO)
        { }
    }
}