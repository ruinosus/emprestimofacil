using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloStatusParcela.Constantes;

namespace RegraNegocio.ModuloStatusParcela.Excecoes
{
    /// <summary>
    /// Classe StatusParcelaNaoExcluidoExcecao
    /// </summary>
    public class StatusParcelaNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public StatusParcelaNaoExcluidoExcecao()
            : base(StatusParcelaConstantes.STATUS_PARCELA_NAOEXCLUIDO)
        { }
    }
}