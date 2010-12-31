using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloEscolaridade.Constantes;

namespace RegraNegocio.ModuloEscolaridade.Excecoes
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