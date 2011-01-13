using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloCliente.Constantes;

namespace SiteMVC.ModuloCliente.Excecoes
{
    /// <summary>
    /// Classe ClienteNaoIncluidoExcecao
    /// </summary>
    public class ClienteNaoIncluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public ClienteNaoIncluidoExcecao()
            : base(ClienteConstantes.CLIENTE_NAOINCLUIDO)
        { }
    }
}