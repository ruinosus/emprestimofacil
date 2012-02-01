using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloArea.Constantes;
using SiteMVCTelerik.ModuloDespesaTipo.Constantes;
namespace SiteMVCTelerik.ModuloDespesaTipo.Excecoes
{
    /// <summary>
    /// Classe DespesaTipoNaoExcluidaExcecao
    /// </summary>
    public class DespesaTipoNaoExcluidaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public DespesaTipoNaoExcluidaExcecao()
            : base(DespesaTipoConstantes.DESPESA_TIPO_NAOEXCLUIDA)
        { }
    }
}