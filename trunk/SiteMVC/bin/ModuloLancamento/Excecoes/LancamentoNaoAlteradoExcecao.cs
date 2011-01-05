using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloLancamento.Constantes;

namespace SiteMVC.ModuloLancamento.Excecoes
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