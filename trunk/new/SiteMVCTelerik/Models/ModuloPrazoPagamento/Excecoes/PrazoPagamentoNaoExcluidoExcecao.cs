using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloPrazoPagamento.Constantes;

namespace SiteMVCTelerik.ModuloPrazoPagamento.Excecoes
{
    /// <summary>
    /// Classe PrazoPagamentoNaoExcluidoExcecao
    /// </summary>
    public class PrazoPagamentoNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public PrazoPagamentoNaoExcluidoExcecao()
            : base(PrazoPagamentoConstantes.PRAZO_PAGAMENTO_NAOEXCLUIDO)
        { }
    }
}