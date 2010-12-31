using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloLancamentoTipo.Constantes;

namespace RegraNegocio.ModuloLancamentoTipo.Excecoes
{
    /// <summary>
    /// Classe LancamentoTipoNaoIncluidoExcecao
    /// </summary>
    public class LancamentoTipoNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public LancamentoTipoNaoIncluidoExcecao()
            : base(LancamentoTipoConstantes.LANCAMENTO_TIPO_NAOINCLUIDO)
        { }
    }
}