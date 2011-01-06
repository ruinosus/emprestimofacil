using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloLancamento.Constantes;

namespace SiteMVC.ModuloLancamento.Excecoes
{
    /// <summary>
    /// Classe LancamentoNaoExcluidoExcecao
    /// </summary>
    public class LancamentoNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public LancamentoNaoExcluidoExcecao()
            : base(LancamentoConstantes.LANCAMENTO_NAOEXCLUIDO)
        { }
    }
}