using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloUsuario.Constantes;

namespace SiteMVC.ModuloUsuario.Excecoes
{
    /// <summary>
    /// Classe UsuarioNaoIncluidoExcecao
    /// </summary>
    public class UsuarioNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public UsuarioNaoIncluidoExcecao()
            : base(UsuarioConstantes.USUARIO_NAOINCLUIDO)
        { }
    }
}