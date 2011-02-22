using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloPrestacaoConta.Constantes;
namespace SiteMVCTelerik.ModuloPrestacaoConta.Excecoes
{
    /// <summary>
    /// Classe PrestacaoContaNaoExcluidaExcecao
    /// </summary>
    public class PrestacaoContaNaoExcluidaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public PrestacaoContaNaoExcluidaExcecao()
            : base(PrestacaoContaConstantes.PRESTACAO_CONTA_NAOEXCLUIDA)
        { }
    }
}