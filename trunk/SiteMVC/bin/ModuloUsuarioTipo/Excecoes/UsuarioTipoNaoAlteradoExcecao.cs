using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloUsuarioTipo.Constantes;

namespace SiteMVC.ModuloUsuarioTipo.Excecoes
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