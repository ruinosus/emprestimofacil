using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloLancamento.Constantes;

namespace RegraNegocio.ModuloLancamento.Excecoes
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