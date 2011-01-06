using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloStatusParcela.Constantes;

namespace SiteMVC.ModuloStatusParcela.Excecoes
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