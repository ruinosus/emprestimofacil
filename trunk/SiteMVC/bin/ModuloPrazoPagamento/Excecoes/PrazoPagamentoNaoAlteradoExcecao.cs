using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloPrazoPagamento.Constantes;

namespace SiteMVC.ModuloPrazoPagamento.Excecoes
{
    /// <summary>
    /// Classe PrazoPagamentoNaoAlteradoExcecao
    /// </summary>
    public class PrazoPagamentoNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public PrazoPagamentoNaoAlteradoExcecao()
            : base(PrazoPagamentoConstantes.PRAZO_PAGAMENTO_NAOALTERADO)
        { }
    }
}