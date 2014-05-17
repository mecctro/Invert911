<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Invert911_WebSite.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Log In
    </h2>
    <asp:Label runat="server" ID="StatusLabel" ForeColor="Green"></asp:Label>
    <p>
        Please enter your username and password.
        <br />
        <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false" NavigateUrl="~/Account/Register.aspx">Register</asp:HyperLink> 
        &nbsp;if you don't have an account.
    </p>

    <%--<asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">--%>
        <%--<LayoutTemplate>--%>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <%--<asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                ValidationGroup="LoginUserValidationGroup"/>--%>
            <asp:Panel ID="p" runat="server" DefaultButton="LoginButton">

                <%--<div class="accountInfo">
                    <fieldset class="login">
                        <legend>Account Information</legend>--%>
                        <p>
                            <asp:Label ID="UserNameLabel" runat="server" >Username:</asp:Label>
                            <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="PasswordLabel" runat="server" >Password:</asp:Label>
                            <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                        </p>
                        
                    <%--</fieldset>--%>
                    <%--<p class="submitButton">--%>
                        <%--<asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"/>--%>
                        <asp:Button ID="LoginButton" runat="server"  Text="Log In" OnClick="LoginButton_Click"/>
                        <%--CommandName="Login"--%>
                    <%--</p>--%>
                <%--</div>--%>
            </asp:Panel>
        <%--</LayoutTemplate>--%>
    <%--</asp:Login>--%>
</asp:Content>
