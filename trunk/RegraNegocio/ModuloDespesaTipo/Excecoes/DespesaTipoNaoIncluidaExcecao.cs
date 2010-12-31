using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloDespesaTipo.Constantes;

namespace RegraNegocio.ModuloDespesaTipo.Excecoes
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