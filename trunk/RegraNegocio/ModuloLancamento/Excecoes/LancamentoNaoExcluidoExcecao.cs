using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloLancamento.Constantes;

namespace Negocios.ModuloLancamento.Excecoes
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