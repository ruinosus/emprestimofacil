using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloArea.Constantes;
namespace SiteMVC.ModuloArea.Excecoes
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