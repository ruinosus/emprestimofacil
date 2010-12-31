using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloStatusParcela.Constantes;

namespace RegraNegocio.ModuloStatusParcela.Excecoes
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