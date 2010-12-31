using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloDespesa.Constantes;

namespace RegraNegocio.ModuloDespesa.Excecoes
{
    /// <summary>
    /// Classe DespesaNaoIncluidaExcecao
    /// </summary>
    public class DespesaNaoIncluidaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public DespesaNaoIncluidaExcecao()
            : base(DespesaConstantes.DESPESA_NAOINCLUIDA)
        { }
    }
}