using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloCliente.Constantes;

namespace SiteMVCTelerik.ModuloCliente.Excecoes
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