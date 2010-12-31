using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloBloqueado.Constantes;

namespace RegraNegocio.ModuloBloqueado.Excecoes
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