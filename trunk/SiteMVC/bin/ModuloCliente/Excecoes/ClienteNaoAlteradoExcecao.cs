using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloCliente.Constantes;

namespace SiteMVC.ModuloCliente.Excecoes
{
    /// <summary>
    /// Classe ClienteNaoAlteradoExcecao
    /// </summary>
    public class ClienteNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public ClienteNaoAlteradoExcecao()
            : base(ClienteConstantes.CLIENTE_NAOALTERADO)
        { }
    }
}