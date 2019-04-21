<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Houses.Model.House>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    发布房屋信息
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="dialog">
        <div class="tit">
            <span class="norTile">新房屋信息发布</span>
            <span class="currTit">填写房屋信息</span>
        </div>
        <div class="box">
            <%Html.BeginForm();%>
                <%= Html.HiddenFor(m => m.HouseId)%>
            <p>
                <span style="width: 80px; text-align: right; display: inline-block">标题：</span>
                <%=Html.TextBoxFor(m=>m.Title) %>
                <span style="color: red"><%=Html.ValidationMessageFor(m=>m.Title) %></span>
            </p>
            <p>
                <span style="width: 80px; text-align: right; display: inline-block">户型：</span>
                <%=Html.EditorFor(m=>m.HouseType) %>
                <span style="color: red"><%=Html.ValidationMessageFor(m=>m.HouseType.Id) %></span>
            </p>
            <p>
                <span style="width: 80px; text-align: right; display: inline-block">面积：</span>
                <%=Html.EditorFor(m=>m.Floorage) %>
                <span style="color: red"><%=Html.ValidationMessageFor(m=>m.Floorage) %></span>
            </p>
            <p>
                <span style="width: 80px; text-align: right; display: inline-block">价格：</span>
                <%=Html.EditorFor(m=>m.Price) %>
                <span style="color: red"><%=Html.ValidationMessageFor(m=>m.Price) %></span>
            </p>
            <p>
                <span style="width: 80px; text-align: right; display: inline-block">位置：</span>
                <%=Html.EditorFor(m=>m.Street.District) %>&nbsp;区&nbsp;
                <span style="color: red">
                    <%=Html.ValidationMessageFor(m=>m.Street.District.Id) %>
                </span>
                <%=Html.EditorFor(m=>m.Street) %>&nbsp;街
                <span style="color: red">
                    <%=Html.ValidationMessageFor(m=>m.Street.Id) %>
                </span>
            </p>
            <p>
                <span style="width: 80px; text-align: right; display: inline-block">联系方式：</span>
                <%=Html.EditorFor(m=>m.Contract) %>
                <span style="color: red"><%=Html.ValidationMessageFor(m=>m.Contract) %></span>
            </p>
            <p>
                <span style="width: 80px; text-align: right; display:inline-block ">详细信息：</span>
                <%=Html.TextAreaFor (m=>m.Description) %>
                <span style="color: red"><%=Html.ValidationMessageFor(m=>m.Description) %></span>
            </p>
            <p style="height: 36px; width: 125px; margin: 30px 0 0 140px;">
                <input type="submit" value="立即发布" class="buttons" />
            </p>
            <%Html.EndForm(); %>
        </div>
    </div>
    <script type="text/javascript">
        $().ready(function () {
            $("#Street_District_Id").change(function () {
                var id = $(this).val();
                if (id > 0) {
                    $.getJSON("<%=Url.Action("GetStreet","House")%>", {
                        'id': id
                    }, function (data) {
                        $("#Street_Id").find("option").remove();
                        $("#Street_Id").append($("<option value=''>--请选择--</option>"));
                        $.each(data, function (i, item) {
                            $("#Street_Id").append($("<option></option>").val(item["Id"]).text(item["Name"]));
                        });
                    });

                }
            });
        });
    </script>
</asp:Content>
