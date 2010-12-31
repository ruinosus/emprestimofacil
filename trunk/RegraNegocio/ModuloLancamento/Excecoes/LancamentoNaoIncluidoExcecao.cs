using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloLancamento.Constantes;

namespace RegraNegocio.ModuloLancamento.Excecoes
{
    /// <summary>
    /// Classe LancamentoNaoIncluidoExcecao
    /// </summary>
    public class LancamentoNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public LancamentoNaoIncluidoExcecao()
            : base(LancamentoConstantes.LANCAMENTO_NAOINCLUIDO)
        { }
    }
}