<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="Invert911_WebSite.FAQ" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
em{font-weight:bold;font-style:normal}</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <p>
        &nbsp;</p>
    <span class="st"><H1>Frequently Asked Questions
    </H1>
<p>&nbsp;</p></span>
    <hr />
    <p>
        <strong>Question: </strong>&nbsp;Why are you writing this application?</p>
    <p>
        <strong>Anwser:</strong>&nbsp; I have worked for a couple of different Public Safety 
        Vendors in the past and now I want to write my own application.&nbsp; I want to work 
        directly with the police officers and avoid all the bureaucracy of public safety 
        vendors.</p>
    <hr />
    <p>
        <strong>Question:</strong>&nbsp; Why are you writing a windows application 
        first?</p>
    <p>
        <strong>Answer:</strong>&nbsp;&nbsp; I want to support disconnected mode for 
        incident report writing.</p>
    <hr />
    <p>
        <strong>Question:</strong>&nbsp; Are you going to write a web application?</p>
    <p>
        <strong>Answer:</strong>&nbsp; Yes, after the basic window RMS application is finished, then I 
        will start the web version.</p>
    <hr />
    <p>
        <strong>Question:</strong>&nbsp; Are you going to create a phone app?</p>
    <p>
        <strong>Answer:</strong>&nbsp; Not at this point.&nbsp;&nbsp; I am planning to 
        write the web application to have basic HTML feature to allow mobile phones and 
        tabets to use it.&nbsp; No need to spend my time creating complex apps on 
        different devices.&nbsp; This is an open source application, so if someone want 
        to create an app the interacts with the application, then that is ok with me.</p>
    <hr />
    
    <p>
        <strong>Question:&nbsp;</strong> Do you provide custom police agency report?</p>
    <p>
        <strong>Answer:&nbsp;</strong> Yes, If the agency provides me with the standard report in PDF 
        format I can generally create the reprot in 40 hours for less</p>
    <hr />
    <p>
        <strong>Question:&nbsp;</strong> Do you provide software support for the application?</p>
    <p>
        <strong>Answer:</strong>&nbsp; Yes, I am avaliable for software support.&nbsp; If the agency is 
        large I have several programmer friends that can also help</p>
    <hr />
    <p>
        <strong>Question:</strong>&nbsp; Do you have security clearance to work on government 
        / police data?</p>
    <p>
        <strong>Answer:</strong>&nbsp; Yes, I am currently working for a California County IT depart and I have 
        past several background checks working for public safety vendors in the past.</p>
    <hr />
    <p>
        <strong>Question:</strong>&nbsp; Is a police agency using this application right 
        now?</p>
<p>
        <strong>Answer:</strong>&nbsp; I am currently working on finishing the Law 
        Incident Field Reporting application.&nbsp; Once the module application is completed, I 
        have a police agency in Utah and in Massachusetts waiting to use the 
        application.&nbsp; I also have a lot of interest from private security agencies.</p>
    <hr />
    <p>
        <strong>Question:</strong>&nbsp; What is the standalone demo Login?</p>
    <p>
        <strong>Answer: </strong>&nbsp;If you are using the standalone client then it is:&nbsp; User Name:&nbsp; Admin&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Password:&nbsp; Admin</p>
    <p>
        If you are uses the Invert911 Cloud client then you need to go to Invert911.com and register your user name and password.</p>
    <hr />
    <p >
        <strong>Question:</strong>&nbsp; Why am I getting the following error when running the full client of Invert911?
        </p><p style="color: #FF0000">Error:  Unable to open the physical file failed. A database with the same name exists, or specified file cannot be opened, or it is located on UNC share</div>
    </p>
    <p>
        <strong>Answer: </strong>&nbsp; For the MDF and LDF files, give full control to your "Authenticated Users".&nbsp; If there is no user in the security settings then add it.

In case you are wondering how to do this --- I am on Windows 7 and the steps go like this:

Right-click on the MDF file and click properties. Select the "Security" tab and select your "Authenticated Users" or click 'Edit' Button then 'Add' button then write 'Autheticated Users' and then 'Check Names' button. Then 'OK' button. Click "Edit" and select the "Allow" check-box for "Full Control". OK all the way out.&nbsp;&nbsp;&nbsp; The MDF and LDF files are located in the install directory of Invert911.&nbsp; I wish microsoft mafe things easier.</p>
    <p>
        Here is a link to the solution:&nbsp; <a href="http://stackoverflow.com/questions/20459228/unable-to-open-the-physical-file-failed-a-database-with-the-same-name-exists-o">Link</a>   

    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    

</asp:Content>
