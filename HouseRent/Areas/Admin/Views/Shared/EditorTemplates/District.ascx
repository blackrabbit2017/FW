<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Houses.Model.District>" %>

<% 
    var data = new Houses.BLL.DistrictManager().GetAll();
    var list = new SelectList(data, "Id", "Name"); 
       %>
<%=Html.DropDownListFor(m=>m.Id, list, "--请选择--", new { @class="selector"})%>