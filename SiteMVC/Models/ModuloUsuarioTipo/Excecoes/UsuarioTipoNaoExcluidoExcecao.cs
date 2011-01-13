using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloUsuarioTipo.Constantes;

namespace SiteMVC.ModuloUsuarioTipo.Excecoes
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