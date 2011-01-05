using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloEscolaridade.Constantes;

namespace SiteMVC.ModuloEscolaridade.Excecoes
{
    /// <summary>
    /// Classe EscolaridadeNaoAlteradaExcecao
    /// </summary>
    public class EscolaridadeNaoAlteradaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public EscolaridadeNaoAlteradaExcecao()
            : base(EscolaridadeConstantes.ESCOLARIDADE_NAOALTERADA)
        { }
    }
}