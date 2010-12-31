using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloLancamentoTipo.Constantes;

namespace RegraNegocio.ModuloLancamentoTipo.Excecoes
{
    /// <summary>
    /// Classe LancamentoTipoNaoExcluidoExcecao
    /// </summary>
    public class LancamentoTipoNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public LancamentoTipoNaoExcluidoExcecao()
            : base(LancamentoTipoConstantes.LANCAMENTO_TIPO_NAOEXCLUIDO)
        { }
    }
}