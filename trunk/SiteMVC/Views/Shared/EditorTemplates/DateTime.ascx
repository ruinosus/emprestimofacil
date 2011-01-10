<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.DateTime>" %>
<%: Html.TextBox("", Model.ToString("dd/MM/yyyy"), new { @class = "datepicker", @maxlength = "10" })%>