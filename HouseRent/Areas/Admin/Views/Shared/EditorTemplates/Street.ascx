<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Houses.Model.Street>" %>

<%
    var temp = new List<SelectListItem>();
    var list = ViewBag.Streets ?? new SelectList(temp);

%>

<%:Html.DropDownListFor(m => m.Id, (SelectList)list, new { @class="selector"})%>