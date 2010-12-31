using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloUsuarioTipo.Constantes;

namespace Negocios.ModuloUsuarioTipo.Excecoes
{
    /// <summary>
    /// Classe UsuarioTipoNaoIncluidoExcecao
    /// </summary>
    public class UsuarioTipoNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public UsuarioTipoNaoIncluidoExcecao()
            : base(UsuarioTipoConstantes.USUARIO_TIPO_NAOINCLUIDO)
        { }
    }
}