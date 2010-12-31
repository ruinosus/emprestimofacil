using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Negocios.ModuloBasico.Constantes;
using Negocios.ModuloCliente.Constantes;

namespace Negocios.ModuloCliente.Excecoes
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