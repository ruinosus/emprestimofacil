using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloArea.Constantes;
namespace RegraNegocio.ModuloArea.Excecoes
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