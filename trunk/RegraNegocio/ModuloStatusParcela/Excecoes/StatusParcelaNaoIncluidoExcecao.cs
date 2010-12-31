using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloStatusParcela.Constantes;

namespace Negocios.ModuloStatusParcela.Excecoes
{
    /// <summary>
    /// Classe StatusParcelaNaoIncluidoExcecao
    /// </summary>
    public class StatusParcelaNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public StatusParcelaNaoIncluidoExcecao()
            : base(StatusParcelaConstantes.STATUS_PARCELA_NAOINCLUIDO)
        { }
    }
}