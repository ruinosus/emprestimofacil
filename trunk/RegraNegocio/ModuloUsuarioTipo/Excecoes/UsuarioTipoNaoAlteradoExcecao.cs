using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloUsuarioTipo.Constantes;

namespace RegraNegocio.ModuloUsuarioTipo.Excecoes
{
    /// <summary>
    /// Classe UsuarioTipoNaoAlteradoExcecao
    /// </summary>
    public class UsuarioTipoNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public UsuarioTipoNaoAlteradoExcecao()
            : base(UsuarioTipoConstantes.USUARIO_TIPO_NAOALTERADO)
        { }
    }
}