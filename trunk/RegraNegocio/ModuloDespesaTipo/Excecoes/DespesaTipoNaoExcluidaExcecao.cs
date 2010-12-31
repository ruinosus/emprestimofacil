using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloArea.Constantes;
namespace Negocios.ModuloArea.Excecoes
{
    /// <summary>
    /// Classe DespesaNaoExcluidaExcecao
    /// </summary>
    public class DespesaNaoExcluidaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public DespesaNaoExcluidaExcecao()
            : base(DespesaConstantes.DESPESA_TIPO_NAOEXCLUIDA)
        { }
    }
}