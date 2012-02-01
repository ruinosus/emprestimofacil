using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloBloqueado.Constantes;

namespace SiteMVCTelerik.ModuloBloqueado.Excecoes
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