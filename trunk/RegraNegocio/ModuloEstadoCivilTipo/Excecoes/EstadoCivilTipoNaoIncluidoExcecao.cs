using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloEstadoCivilTipo.Constantes;

namespace RegraNegocio.ModuloEstadoCivilTipo.Excecoes
{
    /// <summary>
    /// Classe EstadoCivilTipoNaoIncluidoExcecao
    /// </summary>
    public class EstadoCivilTipoNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public EstadoCivilTipoNaoIncluidoExcecao()
            : base(EstadoCivilTipoConstantes.ESTADO_CIVIL_TIPO_NAOINCLUIDO)
        { }
    }
}