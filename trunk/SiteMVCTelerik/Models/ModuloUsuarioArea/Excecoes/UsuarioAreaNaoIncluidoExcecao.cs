using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloUsuarioArea.Constantes;

namespace SiteMVCTelerik.ModuloUsuarioArea.Excecoes
{
    /// <summary>
    /// Classe UsuarioAreaNaoIncluidoExcecao
    /// </summary>
    public class UsuarioAreaNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public UsuarioAreaNaoIncluidoExcecao()
            : base(UsuarioAreaConstantes.USUARIO_AREA_NAOINCLUIDO)
        { }
    }
}