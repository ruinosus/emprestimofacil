using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloCliente.Constantes;

namespace SiteMVC.ModuloCliente.Excecoes
{
    /// <summary>
    /// Classe ClienteNaoExcluidoExcecao
    /// </summary>
    public class ClienteNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public ClienteNaoExcluidoExcecao()
            : base(ClienteConstantes.CLIENTE_NAOEXCLUIDO)
        { }
    }
}