using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloParcela.Constantes;

namespace SiteMVC.ModuloParcela.Excecoes
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