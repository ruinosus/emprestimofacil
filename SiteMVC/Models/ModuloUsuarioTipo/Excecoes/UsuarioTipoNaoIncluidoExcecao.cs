using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloUsuarioTipo.Constantes;

namespace SiteMVC.ModuloUsuarioTipo.Excecoes
{
    /// <summary>
    /// Classe UsuarioTipoNaoIncluidoExcecao
    /// </summary>
    public class UsuarioTipoNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public UsuarioTipoNaoIncluidoExcecao()
            : base(UsuarioTipoConstantes.USUARIO_TIPO_NAOINCLUIDO)
        { }
    }
}