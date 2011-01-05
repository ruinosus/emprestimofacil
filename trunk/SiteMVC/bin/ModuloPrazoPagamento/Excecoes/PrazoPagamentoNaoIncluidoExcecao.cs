using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloPrazoPagamento.Constantes;

namespace SiteMVC.ModuloPrazoPagamento.Excecoes
{
    /// <summary>
    /// Classe PrazoPagamentoNaoIncluidoExcecao
    /// </summary>
    public class PrazoPagamentoNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public PrazoPagamentoNaoIncluidoExcecao()
            : base(PrazoPagamentoConstantes.PRAZO_PAGAMENTO_NAOINCLUIDO)
        { }
    }
}