using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloUsuario.Constantes;

namespace RegraNegocio.ModuloUsuario.Excecoes
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