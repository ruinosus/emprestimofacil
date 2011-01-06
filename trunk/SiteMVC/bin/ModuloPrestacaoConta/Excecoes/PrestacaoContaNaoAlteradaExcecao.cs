using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloPrestacaoConta.Constantes;

namespace SiteMVC.ModuloPrestacaoConta.Excecoes
{
    /// <summary>
    /// Classe PrestacaoContaNaoAlteradaExcecao
    /// </summary>
    public class PrestacaoContaNaoAlteradaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public PrestacaoContaNaoAlteradaExcecao()
            : base(PrestacaoContaConstantes.PRESTACAO_CONTA_NAOALTERADA)
        { }
    }
}