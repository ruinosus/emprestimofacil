using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloParcela.Constantes;

namespace Negocios.ModuloParcela.Excecoes
{
    /// <summary>
    /// Classe ParcelaNaoAlteradaExcecao
    /// </summary>
    public class ParcelaNaoAlteradaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public ParcelaNaoAlteradaExcecao()
            : base(ParcelaConstantes.PARCELA_NAOALTERADA)
        { }
    }
}