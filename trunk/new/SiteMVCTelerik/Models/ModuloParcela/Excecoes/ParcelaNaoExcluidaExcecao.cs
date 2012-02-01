using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloParcela.Constantes;
namespace SiteMVCTelerik.ModuloParcela.Excecoes
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