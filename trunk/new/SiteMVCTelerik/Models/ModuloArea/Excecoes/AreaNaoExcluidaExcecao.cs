using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloArea.Constantes;
namespace SiteMVCTelerik.ModuloArea.Excecoes
{
    /// <summary>
    /// Classe AreaNaoExcluidaExcecao
    /// </summary>
    public class AreaNaoExcluidaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public AreaNaoExcluidaExcecao()
            : base(AreaConstantes.AREA_NAOEXCLUIDA)
        { }
    }
}