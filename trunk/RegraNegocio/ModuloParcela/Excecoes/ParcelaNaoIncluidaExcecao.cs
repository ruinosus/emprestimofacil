using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloParcela.Constantes;

namespace RegraNegocio.ModuloParcela.Excecoes
{
    /// <summary>
    /// Classe ParcelaNaoIncluidaExcecao
    /// </summary>
    public class ParcelaNaoIncluidaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public ParcelaNaoIncluidaExcecao()
            : base(ParcelaConstantes.PARCELA_NAOINCLUIDA)
        { }
    }
}