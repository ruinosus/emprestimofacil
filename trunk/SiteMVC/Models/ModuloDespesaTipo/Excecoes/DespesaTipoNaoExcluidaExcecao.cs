using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloArea.Constantes;
using SiteMVC.ModuloDespesaTipo.Constantes;
namespace SiteMVC.ModuloDespesaTipo.Excecoes
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