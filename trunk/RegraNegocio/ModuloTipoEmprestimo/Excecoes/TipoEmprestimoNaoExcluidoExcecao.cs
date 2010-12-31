using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloTipoEmprestimo.Constantes;

namespace RegraNegocio.ModuloTipoEmprestimo.Excecoes
{
    /// <summary>
    /// Classe TipoEmprestimoNaoExcluidoExcecao
    /// </summary>
    public class TipoEmprestimoNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public TipoEmprestimoNaoExcluidoExcecao()
            : base(TipoEmprestimoConstantes.TIPO_EMPRESTIMO_NAOEXCLUIDO)
        { }
    }
}