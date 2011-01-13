using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloDespesa.Constantes;

namespace SiteMVC.ModuloDespesa.Excecoes
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