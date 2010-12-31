using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloBloqueado.Constantes;

namespace Negocios.ModuloBloqueado.Excecoes
{
    /// <summary>
    /// Classe BloqueadoNaoIncluidoExcecao
    /// </summary>
    public class BloqueadoNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public BloqueadoNaoIncluidoExcecao()
            : base(BloqueadoConstantes.BLOQUEADO_NAOINCLUIDO)
        { }
    }
}