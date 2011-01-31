using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloUsuarioArea.Constantes;

namespace SiteMVC.ModuloUsuarioArea.Excecoes
{
    /// <summary>
    /// Classe UsuarioAreaNaoExcluidoExcecao
    /// </summary>
    public class UsuarioAreaNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public UsuarioAreaNaoExcluidoExcecao()
            : base(UsuarioAreaConstantes.USUARIO_AREA_NAOEXCLUIDO)
        { }
    }
}