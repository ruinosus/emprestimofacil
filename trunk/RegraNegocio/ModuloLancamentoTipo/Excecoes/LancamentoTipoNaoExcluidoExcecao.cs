using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloLancamentoTipo.Constantes;

namespace Negocios.ModuloLancamentoTipo.Excecoes
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