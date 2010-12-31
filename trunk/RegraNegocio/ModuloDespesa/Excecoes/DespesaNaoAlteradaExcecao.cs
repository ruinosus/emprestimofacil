using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloDespesa.Constantes;

namespace Negocios.ModuloDespesa.Excecoes
{
    /// <summary>
    /// Classe DespesaNaoAlteradaExcecao
    /// </summary>
    public class DespesaNaoAlteradaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public DespesaNaoAlteradaExcecao()
            : base(DespesaConstantes.DESPESA_NAOALTERADA)
        { }
    }
}