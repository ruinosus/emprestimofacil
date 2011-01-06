using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloLancamentoTipo.Constantes;

namespace SiteMVC.ModuloLancamentoTipo.Excecoes
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