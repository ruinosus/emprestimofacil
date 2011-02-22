using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloUsuarioTipo.Constantes;

namespace SiteMVCTelerik.ModuloUsuarioTipo.Excecoes
{
    /// <summary>
    /// Classe UsuarioTipoNaoExcluidoExcecao
    /// </summary>
    public class UsuarioTipoNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public UsuarioTipoNaoExcluidoExcecao()
            : base(UsuarioTipoConstantes.USUARIO_TIPO_NAOEXCLUIDO)
        { }
    }
}