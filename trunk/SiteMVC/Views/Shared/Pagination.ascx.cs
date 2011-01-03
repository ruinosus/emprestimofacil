using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteMVC.Views.Shared
{
     public class PaginationViewData  
     {  
         public int PageIndex { get; set; }  
         public int TotalPages { get; set; }  
         public int PageSize { get; set; }  
         public int TotalCount { get; set; }  
         public string PageActionLink { get; set; }  
         public bool HasPreviousPage  
         {  
             get  
             {  
                 return (PageIndex > 1);  
             }  
         }  
   
         public bool HasNextPage  
         {  
             get  
             {  
                 return (PageIndex * PageSize) <= TotalCount;  
             }  
         }  
     }  
   
     public partial class Pagination : System.Web.Mvc.ViewUserControl<PaginationViewData>  
     {  
         public Pagination()  
         {  
   
         }  
     }  
 }  