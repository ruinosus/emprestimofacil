using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloArea.Constantes;
namespace Negocios.ModuloArea.Excecoes
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
            : base(AreaConstantes.DESPESA_TIPO_NAOEXCLUIDA)
        { }
    }
}