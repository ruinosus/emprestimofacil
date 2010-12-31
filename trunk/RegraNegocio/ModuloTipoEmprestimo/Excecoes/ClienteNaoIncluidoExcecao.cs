using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloTipoEmprestimo.Constantes;

namespace Negocios.ModuloTipoEmprestimo.Excecoes
{
    /// <summary>
    /// Classe TipoEmprestimoNaoIncluidoExcecao
    /// </summary>
    public class TipoEmprestimoNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public TipoEmprestimoNaoIncluidoExcecao()
            : base(TipoEmprestimoConstantes.TIPO_EMPRESTIMO_NAOINCLUIDO)
        { }
    }
}