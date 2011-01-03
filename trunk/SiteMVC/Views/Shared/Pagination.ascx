    <%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pagination.ascx.cs" Inherits="Mvc2.Views.Shared.Pagination" %>  
    <ul class="pagination-clean">  
        <% if (ViewData.HasPreviousPage)  
            { %>  
              <li class="previous"><a href="<%=ViewData.PageActionLink.Replace("%7Bpage%7D", (ViewData.PageIndex - 1).ToString())%>">« Previous</a></li>  
         <% }  
           else  
            { %>  
              <li class="previous-off">« Previous</li>  
        <% } %>  
     
        <%for (int page = 1; page <= ViewData.TotalPages; page++)  
           {  
           if (page == ViewData.PageIndex)  
               { %>  
                 <li class="active"><%=page.ToString()%></li>  
            <% }  
           else  
               { %>  
                 <li><a href="<%=ViewData.PageActionLink.Replace("%7Bpage%7D", page.ToString())%>"><%=page.ToString()%></a></li>  
            <% }  
           }   
     
          if (ViewData.HasNextPage)  
               { %>  
                <li class="next"><a href="<%=ViewData.PageActionLink.Replace("%7Bpage%7D", (ViewData.PageIndex + 1).ToString())%>">Next »</a></li>  
           <% }  
         else  
              { %>  
                 <li class="next-off">Next »</li>  
           <% } %>  
  </ul>   