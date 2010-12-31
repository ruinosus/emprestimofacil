using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloDespesaTipo.Constantes;

namespace Negocios.ModuloDespesaTipo.Excecoes
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