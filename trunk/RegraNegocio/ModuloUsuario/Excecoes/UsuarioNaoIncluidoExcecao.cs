using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloUsuario.Constantes;

namespace RegraNegocio.ModuloUsuario.Excecoes
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