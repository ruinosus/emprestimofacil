<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.TimeSpan>" %>
<%: Html.TextBox("", new DateTime(Model.Ticks).ToString("h:mm tt"), new { @class = "timedropdown", @maxlength = "8" })%>
