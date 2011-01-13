using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloEscolaridade.Constantes;
namespace SiteMVC.ModuloEscolaridade.Excecoes
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