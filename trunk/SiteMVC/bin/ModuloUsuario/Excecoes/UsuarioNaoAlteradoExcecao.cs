using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloUsuario.Constantes;

namespace SiteMVC.ModuloUsuario.Excecoes
{
    /// <summary>
    /// Classe UsuarioNaoAlteradoExcecao
    /// </summary>
    public class UsuarioNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public UsuarioNaoAlteradoExcecao()
            : base(UsuarioConstantes.USUARIO_NAOALTERADO)
        { }
    }
}