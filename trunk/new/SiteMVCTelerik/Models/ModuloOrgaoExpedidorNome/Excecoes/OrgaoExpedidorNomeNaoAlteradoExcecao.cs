using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SiteMVCTelerik.ModuloBasico.Constantes;
using SiteMVCTelerik.ModuloOrgaoExpedidorNome.Constantes;

namespace SiteMVCTelerik.ModuloOrgaoExpedidorNome.Excecoes
{
    /// <summary>
    /// Classe OrgaoExpedidorNomeNaoAlteradoExcecao
    /// </summary>
    public class OrgaoExpedidorNomeNaoAlteradoExcecao: Exception
    {
        /// <summary>
        /// Contrutor da classe de exception, 
        /// passando como mensagem a constante. 
        /// </summary>
        public OrgaoExpedidorNomeNaoAlteradoExcecao()
            : base(OrgaoExpedidorNomeConstantes.ORGAO_EXPEDIDOR_NOME_NAOALTERADO)
        { }
    }
}