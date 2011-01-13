using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloDespesaTipo.Constantes;

namespace SiteMVC.ModuloDespesaTipo.Excecoes
{
    /// <summary>
    /// Classe DespesaTipoNaoIncluidaExcecao
    /// </summary>
    public class DespesaTipoNaoIncluidaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public DespesaTipoNaoIncluidaExcecao()
            : base(DespesaTipoConstantes.DESPESA_TIPO_NAOINCLUIDA)
        { }
    }
}