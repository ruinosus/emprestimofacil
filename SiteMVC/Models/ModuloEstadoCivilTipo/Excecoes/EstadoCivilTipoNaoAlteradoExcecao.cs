using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloEstadoCivilTipo.Constantes;

namespace SiteMVC.ModuloEstadoCivilTipo.Excecoes
{
    /// <summary>
    /// Classe EstadoCivilTipoNaoAlteradoExcecao
    /// </summary>
    public class EstadoCivilTipoNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public EstadoCivilTipoNaoAlteradoExcecao()
            : base(EstadoCivilTipoConstantes.ESTADO_CIVIL_TIPO_NAOALTERADO)
        { }
    }
}