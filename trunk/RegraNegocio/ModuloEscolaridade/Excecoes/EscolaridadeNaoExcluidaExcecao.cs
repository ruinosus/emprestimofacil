using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloEscolaridade.Constantes;
namespace Negocios.ModuloEscolaridade.Excecoes
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