using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloDespesaTipo.Constantes;

namespace SiteMVCTelerik.ModuloDespesaTipo.Excecoes
{
    /// <summary>
    /// Classe DespesaTipoNaoAlteradaExcecao
    /// </summary>
    public class DespesaTipoNaoAlteradaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public DespesaTipoNaoAlteradaExcecao()
            : base(DespesaTipoConstantes.DESPESA_TIPO_NAOALTERADA)
        { }
    }
}