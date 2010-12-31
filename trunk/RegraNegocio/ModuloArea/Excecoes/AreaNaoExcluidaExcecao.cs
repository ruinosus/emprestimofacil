using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloArea.Constantes;
namespace RegraNegocio.ModuloArea.Excecoes
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