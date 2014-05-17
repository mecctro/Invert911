<%@ Page Title="Invert911 - Downloads" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Downloads.aspx.cs" Inherits="Invert911_WebSite.Downloads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Downloads
    </h1>
    <p>
        <a href="Downloads/InvertInstaller.msi">Invert911 Installer</a>&nbsp; (Full and Cloud Installer)</p>
        
    <%--<h2>
        Invert911 lite App</h2>
    <p>
        Invert911 Lite software has only the law incident module with no backend 
        database.&nbsp; It only creates and edits XML law incident reports.&nbsp; It 
        also has a code admin modules so the user can add or edit comboboxes in the law 
        incident module.&nbsp; I created this application to help some demo users that a 
        hard time installing sql server.</p>--%>
    <h2>
        Invert911 Cloud App</h2>
    <p>
        Invert911 cloud app is a version of the application that uses a database on the 
        cloud.&nbsp; This app requires you to register your user on the Invert911.com 
        domain.&nbsp; You will be able to test out the different modules and save all 
        the information on the cloud (remote server) database</p>
    <h2>
        Invert911 Full 
        App (Client EXE, App Server, Database)</h2>
    <p>
        Invert911 has created a working demo of the application so the law enforcement 
        community can try out the software and see if it is the right fit for their 
        agency.&nbsp;&nbsp; The demo is like the full version of the software except 
        that it is all running on the client machine and it is using SQL Server 2008 r2 
        Express instead of the normal SQL Server and a web service backend.&nbsp;&nbsp;
</p>
<h5>required Supporting Tools for Invert911 Demo:</h5>  
<ul>
    <li><a href="http://www.microsoft.com/en-us/download/details.aspx?id=26729">SQL Server 2008 R2 Express</a>:&nbsp; Please download the installer that works with 
        your system&nbsp;
        <ul>
            <li><a href="Downloads/SQLEXPR_x86_ENU.exe">SQL Server 2008 r2 Express - 32 bit verison </a></li>
            <li><a href="Downloads/SQLEXPR_x64_ENU.exe">SQL Server 2008 r2 Express - 64 bit verison of </a>
                <br />
            </li>
        </ul>
    </li>
    <li>.Net 4.0 full client is also .&nbsp; The installer should direct you to 
        the correct Microsoft site to install the software.&nbsp; If not, use the link 
        below<ul>
            <li><a href="http://www.microsoft.com/en-us/download/details.aspx?displaylang=en&amp;id=17851">.Net 4.0 full Install</a></li>
        </ul>
    </li>
</ul>

    <%--<li><a href="http://www.invert911.com/publish.htm">Install Invert911 Application</a></li>--%>
    <%--<h5>
        Invert911 demo Installer:</h5>
    <ul>
        <li><a href="Downloads/InvertInstaller_x86.msi">Invert911 Demo - 32 bit Version</a><br />
        </li>
        <li><a href="Downloads/InvertInstaller_x64.msi">Invert911 Demo - 64 bit Version</a><br />
        </li>
    </ul>--%>
    <h2>
        Source Code</h2>
<br/>
<%--Police Incident Entry:<br/>
<img src="../.././Images/I9IncEntry.png" alt="Incident Entry" width='50%' height='50%'/>--%>


Invert911 is a open source project for the public safety industry.&nbsp;   The latest source code is available upon request 
    or you can get a older copy of the source code at <a href="http://invert911.codeplex.com/">
http://invert911.codeplex.com/</a>.&nbsp;&nbsp;    
If you has any questions please email me at <a href="mailto:Eric@Invert911.com"> Eric@Invert911.com</a>.&nbsp; <br />
<br/>
Screenshot of the Source Code:<br/>
<img src="Images/I9SourceCode.png" alt="Source Code"/>


</asp:Content>
