using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloStatusParcela.Constantes;

namespace SiteMVCTelerik.ModuloStatusParcela.Excecoes
{
    /// <summary>
    /// Classe StatusParcelaNaoAlteradoExcecao
    /// </summary>
    public class StatusParcelaNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public StatusParcelaNaoAlteradoExcecao()
            : base(StatusParcelaConstantes.STATUS_PARCELA_NAOALTERADO)
        { }
    }
}