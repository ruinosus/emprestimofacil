using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloBloqueado.Constantes;

namespace Negocios.ModuloBloqueado.Excecoes
{
    /// <summary>
    /// Classe BloqueadoNaoExcluidoExcecao
    /// </summary>
    public class BloqueadoNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public BloqueadoNaoExcluidoExcecao()
            : base(BloqueadoConstantes.BLOQUEADO_NAOEXCLUIDO)
        { }
    }
}