using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloStatusParcela.Constantes;

namespace SiteMVCTelerik.ModuloStatusParcela.Excecoes
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