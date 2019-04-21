<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Houses.Model.HouseType>" %>

<%
    var types = new Houses.BLL.HouseTypeManager().GetAll();
    var list = new SelectList(types, "Id", "Name");
     %>

<%:Html.DropDownListFor(m => m.Id, list, "--请选择--", new { @class="selector"})%>