<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Houses.Model.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    用户注册
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="dialog">
        <div class="tit">
            <span class="norTile">新用户注册</span>
            <span class="currTit">填写个人信息</span>
        </div>
        <div class="box">
            <%Html.BeginForm() ;%>
            <p><span style="width:80px;text-align:right;display:inline-block">用户名：</span>
                <%=Html.TextBoxFor(m=>m.LoginName) %>
                <span style="color:red"><%=Html.ValidationMessageFor(m=>m.LoginName) %></span></p>
            <p><span style="width:80px;text-align:right;display:inline-block">密码：</span>
                <%=Html.PasswordFor(m=>m.Password) %>
                <span style="color:red"><%=Html.ValidationMessageFor(m=>m.Password) %></span></p>
            <p><span style="width:80px;text-align:right;display:inline-block">确认密码：</span>
                <%=Html.PasswordFor(m=>m.RePassword) %>
                <span style="color:red"><%=Html.ValidationMessageFor(m=>m.RePassword) %></span></p>
            <p><span style="width:80px;text-align:right;display:inline-block">电话：</span>
                <%=Html.TextBoxFor(m=>m.Telephone) %>
                <span style="color:red"><%=Html.ValidationMessageFor(m=>m.Telephone) %></span></p>
            <p><span style="width:80px;text-align:right;display:inline-block">用户姓名：</span>
                <%=Html.TextBoxFor(m=>m.UserName) %>
                <span style="color:red"><%=Html.ValidationMessageFor(m=>m.UserName) %></span></p>
            <p style="height:36px;width:125px;margin: 30px 0 0 140px;">
                <input type="submit" value="立即注册" class="buttons" />
            </p>
            <%Html.EndForm(); %>
        </div>
    </div>

</asp:Content>
