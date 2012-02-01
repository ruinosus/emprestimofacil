using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloUsuarioArea.Constantes;

namespace SiteMVCTelerik.ModuloUsuarioArea.Excecoes
{
    /// <summary>
    /// Classe UsuarioAreaNaoAlteradoExcecao
    /// </summary>
    public class UsuarioAreaNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public UsuarioAreaNaoAlteradoExcecao()
            : base(UsuarioAreaConstantes.USUARIO_AREA_NAOALTERADO)
        { }
    }
}