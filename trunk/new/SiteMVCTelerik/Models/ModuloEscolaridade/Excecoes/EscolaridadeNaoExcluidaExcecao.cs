using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloEscolaridade.Constantes;
namespace SiteMVCTelerik.ModuloEscolaridade.Excecoes
{
    /// <summary>
    /// Classe EscolaridadeNaoExcluidaExcecao
    /// </summary>
    public class EscolaridadeNaoExcluidaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public EscolaridadeNaoExcluidaExcecao()
            : base(EscolaridadeConstantes.ESCOLARIDADE_NAOEXCLUIDA)
        { }
    }
}