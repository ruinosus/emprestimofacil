using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegraNegocio.ModuloBasico.Constantes;
using RegraNegocio.ModuloCliente.Constantes;

namespace RegraNegocio.ModuloCliente.Excecoes
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