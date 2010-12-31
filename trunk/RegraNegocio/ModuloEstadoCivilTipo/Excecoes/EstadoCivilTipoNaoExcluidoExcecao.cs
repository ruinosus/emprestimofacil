using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloEstadoCivilTipo.Constantes;

namespace RegraNegocio.ModuloEstadoCivilTipo.Excecoes
{
    /// <summary>
    /// Classe EstadoCivilTipoNaoExcluidoExcecao
    /// </summary>
    public class EstadoCivilTipoNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public EstadoCivilTipoNaoExcluidoExcecao()
            : base(EstadoCivilTipoConstantes.ESTADO_CIVIL_TIPO_NAOEXCLUIDO)
        { }
    }
}