<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.DateTime>" %>
<%: Html.TextBox("", Model.ToShortDateString(), new { @class = "datepicker", @maxlength = "10" })%>