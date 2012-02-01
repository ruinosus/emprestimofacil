using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloArea.Constantes;

namespace SiteMVCTelerik.ModuloArea.Excecoes
{
    /// <summary>
    /// Classe AreaNaoIncluidaExcecao
    /// </summary>
    public class AreaNaoIncluidaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public AreaNaoIncluidaExcecao()
            : base(AreaConstantes.AREA_NAOINCLUIDA)
        { }
    }
}