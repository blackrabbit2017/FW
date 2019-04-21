<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Houses.Model.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    用户登录
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="login" >
        <h3>用户登录</h3>
        <div class="loginForm">
            <%
                Html.BeginForm();
                 %>
            <p>用户名：<%=Html.TextBoxFor(m=>m.LoginName) %>
                <span style="color:red"><%=Html.ValidationMessageFor(m=>m.LoginName) %></span></p>
            <p>密&nbsp;&nbsp;&nbsp;码：<%=Html.PasswordFor(m=>m.Password) %>
                <span style="color:red"><%=Html.ValidationMessageFor(m=>m.Password) %></span></p>
            <p class="btnBox">
                <input type="submit" value="立即登录" class="buttons"/>
                <input type="button" value="注册" class="buttons" onclick="location.href='<%=Url.Action("Register")%>'"/>
            </p>
            <%Html.EndForm(); %>
        </div>
    </div>

</asp:Content>
