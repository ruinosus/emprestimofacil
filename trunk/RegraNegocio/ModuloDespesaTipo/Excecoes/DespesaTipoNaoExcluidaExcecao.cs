using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloArea.Constantes;
using RegraNegocio.ModuloDespesaTipo.Constantes;
namespace RegraNegocio.ModuloArea.Excecoes
{
    /// <summary>
    /// Classe DespesaTipoNaoExcluidaExcecao
    /// </summary>
    public class DespesaTipoNaoExcluidaExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public DespesaTipoNaoExcluidaExcecao()
            : base(DespesaTipoConstantes.DESPESA_TIPO_NAOEXCLUIDA)
        { }
    }
}