<%@ Page Title="Invert911 - Screenshots" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Screenshot.aspx.cs" Inherits="Invert911_WebSite.Screenshot" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>List of Screenshots:</h2>
    
    <h3>
    <div runat="server" id="xmlGeneratedContent"></div>
    </h3>


    <%--<asp:ListBox ID="ListBox1" runat="server" Width="100%" Height="180px" AutoPostBack="true">
        <asp:ListItem>I9DynamicEntryAdmin.png</asp:ListItem>
        <asp:ListItem>I9DynamicEntryAdmin.png</asp:ListItem>
        <asp:ListItem>I9DynamicEntryAdmin.png</asp:ListItem>
        <asp:ListItem>I9DynamicEntryAdmin.png</asp:ListItem>
    </asp:ListBox>

    <br />
    <asp:CheckBox ID="DisplayLargeImagesCheckBox" runat="server" AutoPostBack="true" Checked="false" Text="Display Large Images" />
    <br />
    <br />
    <asp:Image ID="Image1" Width="900" runat="server"  ImageUrl="~/Screenshots/Invert911_Night_Mode.png" />--%>
    <%--<asp:Image ID="Image2" Width="900" runat="server"  ImageUrl="~/Screenshots/Invert911_Night_Mode.png" />--%>    
    
        
<%--    <asp:Table ID="Table1" runat="server" Width="100%">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server" Width="30%" BorderWidth="1">
                <asp:ListBox ID="ListBox1" runat="server" Width="100%" Height="600" AutoPostBack="true">
                    <asp:ListItem>I9DynamicEntryAdmin.png</asp:ListItem>
                    <asp:ListItem>I9DynamicEntryAdmin.png</asp:ListItem>
                    <asp:ListItem>I9DynamicEntryAdmin.png</asp:ListItem>
                    <asp:ListItem>I9DynamicEntryAdmin.png</asp:ListItem>
                </asp:ListBox>
            </asp:TableCell>
            <asp:TableCell runat="server" Width="70%" BorderWidth="1" VerticalAlign="Top">
                    
                <asp:Image ID="Image1" Width="750" runat="server"  ImageUrl="~/Screenshots/Invert911_Night_Mode.png" />

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server">
            
        </asp:TableRow>
    </asp:Table>--%>

</asp:Content>
