using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloLancamentoTipo.Constantes;

namespace SiteMVCTelerik.ModuloLancamentoTipo.Excecoes
{
    /// <summary>
    /// Classe LancamentoTipoNaoAlteradoExcecao
    /// </summary>
    public class LancamentoTipoNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public LancamentoTipoNaoAlteradoExcecao()
            : base(LancamentoTipoConstantes.LANCAMENTO_TIPO_NAOALTERADO)
        { }
    }
}