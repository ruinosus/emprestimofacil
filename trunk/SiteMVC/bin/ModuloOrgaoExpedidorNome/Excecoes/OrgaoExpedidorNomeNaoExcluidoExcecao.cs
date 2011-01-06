using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVC.ModuloBasico.Constantes;
using SiteMVC.ModuloOrgaoExpedidorNome.Constantes;

namespace SiteMVC.ModuloOrgaoExpedidorNome.Excecoes
{
    /// <summary>
    /// Classe OrgaoExpedidorNomeNaoExcluidoExcecao
    /// </summary>
    public class OrgaoExpedidorNomeNaoExcluidoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public OrgaoExpedidorNomeNaoExcluidoExcecao()
            : base(OrgaoExpedidorNomeConstantes.ORGAO_EXPEDIDOR_NOME_NAOEXCLUIDO)
        { }
    }
}