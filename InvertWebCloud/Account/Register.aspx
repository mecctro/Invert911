<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="Invert911_WebSite.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>


<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

        <h2>
            Create a New Account
        </h2>
        <p>
            Use the form below to create a new account.&nbsp; All new user accounts will be assigned a Demo User Security group, which will enable you to only add and edit law incident reports.&nbsp; If you want to use the entire invert911 system you will need to setup a full system on your local machine or setup another invert911 cloud system which you will have full access too.&nbsp; If you need help setting up another invert911 clound system, just email me.&nbsp; I think Amazon AWS service is cheap to use.&nbsp;
        </p>
        <p>
            Passwords are required to be a minimum of 8 characters in length.
        </p>
        <span class="failureNotification">
            <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
        </span>
        <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                ValidationGroup="RegisterUserValidationGroup"/>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Account Information</legend>
                <p>
                    <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstName">First Name:</asp:Label>
                    <asp:TextBox ID="FirstName" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" ControlToValidate="FirstName" 
                            CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required." 
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastName">Last Name:</asp:Label>
                    <asp:TextBox ID="LastName" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="LastName" 
                            CssClass="failureNotification" ErrorMessage="Last Name is required." ToolTip="Last Name is required." 
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                    <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                            CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                    <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                            CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                            ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </p>
                <p>
                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                    <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                            ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                            ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                            CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                            ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                </p>
            </fieldset>
            
            <p class="submitButton">
                <asp:Button ID="CreateUserButton" runat="server" Text="Create User" 
                        ValidationGroup="RegisterUserValidationGroup" 
                         OnClick   ="CreateUserButton_Click"/>

            </p>
        </div>
</asp:Content>
