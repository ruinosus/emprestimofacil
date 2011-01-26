<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SiteMVC.Models.ModuloBasico.VOs.Parcela>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ImprimirParcelas
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        ImprimirParcelas</h2>
    <script type="text/javascript">
        function CallPrint(strid) {

            var prtContent = document.getElementById(strid);

            var WinPrint = window.open('', '', 'letf=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');

            WinPrint.document.write(prtContent.innerHTML);

            WinPrint.document.close();

            WinPrint.focus();

            WinPrint.print();

            WinPrint.close();

            prtContent.innerHTML = strOldOne;

        }
    </script>

    <%
        decimal quantidadePaginas = (decimal)ViewData["quantidadePaginas"];
        int cont = 0;
        int paginaAtual = -1;
        int cont2 = 0;
       
        for (int j = 0; j < quantidadePaginas; j++)
      {
          cont = 0;
          paginaAtual++;
     %>
    <div id="divPrint<%:j%>">
        <table border="1" width="100%">

            <%
          //int valorMaximo = 5;

          //if (Model.Count() <= 5)
          //{
          //    valorMaximo = Model.Count();
          //}
          
          
                int i = 0;
                SiteMVC.Models.ModuloBasico.VOs.Parcela item = new SiteMVC.Models.ModuloBasico.VOs.Parcela();
                List<SiteMVC.Models.ModuloBasico.VOs.Parcela> lista = (List<SiteMVC.Models.ModuloBasico.VOs.Parcela>)Model;
                for (int k = cont2; k < lista.Count; k++)
               {
                   item = lista[k];
                   i++;
                   cont++;
                   cont2++;
                   if (cont > 5)
                       break;
                     %>
            <tr>
                <td style="width: 50%">
                    <table cellpadding="0" cellspacing="0" border="1" width="100%">
                        <tr>
                            <td colspan="2">
                                Emprest Fácil - Documento:
                            </td>
                            <td>
                                  <%: item.ID %>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                 <%: item.emprestimo.cliente.ID%> -   <%: item.emprestimo.cliente.nome%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Area:
                            </td>
                            <td colspan="2">
                              <%: item.emprestimo.cliente.area.descricao %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vendedor:
                            </td>
                            <td colspan="2">
                             <%: item.emprestimo.usuario.nome%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vencimento:
                            </td>
                            <td colspan="2">
                             <%: item.data_vencimento.ToString("dd/MM/yyyy")%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Parcela:
                            </td>
                            <td colspan="2">
                             <%: i %>/<%: Model.Count() %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Valor R$:
                            </td>
                            <td colspan="2">
                            <%: item.valor%>
                            </td>
                        </tr>
                         <tr>
                            <td colspan="3">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                            </td>
                            
                        </tr>
                          <tr>
                            <td colspan="3">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                            </td>
                            
                        </tr>

                    </table>
                    
                </td>
                <td style="width: 50%">
                <table class="clear" cellpadding="0" cellspacing="0" border="1" width="100%">
                        <tr>
                            <td colspan="2">
                                Emprest Fácil - Documento:
                            </td>
                            <td>
                                  <%: item.ID %>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                 <%: item.emprestimo.cliente.ID%> -   <%: item.emprestimo.cliente.nome%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Area:
                            </td>
                            <td colspan="2">
                              <%: item.emprestimo.cliente.area.descricao %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vendedor:
                            </td>
                            <td colspan="2">
                             <%: item.emprestimo.usuario.nome%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Vencimento:
                            </td>
                            <td colspan="2">
                             <%: item.data_vencimento.ToString("dd/MM/yyyy")%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Parcela:
                            </td>
                            <td colspan="2">
                             <%: i %>/<%: Model.Count() %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Valor R$:
                            </td>
                            <td colspan="2">
                            <%: item.valor%>
                            </td>
                        </tr>
                          <tr>
                            <td colspan="3" >
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                            </td>
                            
                        </tr>
                          <tr>
                            <td colspan="3" >
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                            </td>
                            
                        </tr>

                    </table>
                </td>
            </tr>
            <% } %>
        </table>
    </div>
    <input type="image" src="../../Content/ui-lightness/images/impressora.jpg" onclick="CallPrint('divPrint<%:j%>');"
        style="width: 40px; height: 40px" />
         <%} %>
</asp:Content>
