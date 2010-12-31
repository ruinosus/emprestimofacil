using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloParcela.Constantes;
namespace Negocios.ModuloParcela.Excecoes
{
    /// <summary>
    /// Classe ParcelaNaoExcluidaExcecao
    /// </summary>
    public class ParcelaNaoExcluidaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public ParcelaNaoExcluidaExcecao()
            : base(ParcelaConstantes.PARCELA_NAOEXCLUIDA)
        { }
    }
}