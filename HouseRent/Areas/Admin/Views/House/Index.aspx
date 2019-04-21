<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PagedList<Houses.Model.House>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    租房信息维护
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="house-list">
        <%
            int index = 0;
            foreach (var item in Model)
            {
             %>
        <tr <%if(index%2==0) {%>class="odd"<%} %>>
            <td class="house-thumb">
                <dl>
                    <dt><span><img src="<%=Url.Content("~/Images/thumb_house.gif") %>"/></span></dt>
                    <dd><a href="#"><%=item.Title %></a></dd>
                    <dd><%=item.Street.District.Name %>区<%=item.Street.Name %>，<%=item.Floorage %>平米</dd>
                    <dd>联系方式：<%=item.Contract %></dd>
                </dl>
            </td>
            <td class="house-type">
                <label class="ui-green">
                    <input type="button" value="修改" onclick="location.href='<%=Url.Action("Edit","House",new { id=item.HouseId })%>'"/>
                </label>
            </td>
            <td class="house-price">
                <label class="ui-green">
                    <input type="button" value="删除" onclick="Del(<%=item.HouseId%>)"/>
                </label>
            </td>
        </tr>
        <%
                index++;
            } %>
    </table>
    <%=Html.Pager(Model) %>
    <script type="text/javascript">
        function Del(id){
            if( confirm("确定要删除这条记录吗？")){
                location.href='<%=Url.Action("Delete", "House")%>'+"/"+id;
            }
        }
    </script>
</asp:Content>
