using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using Invert911.InvertCommon.Messages.Admin;
using Invert911.InvertCommon.Framework.Communication;
using InvertService.BusinessLib;

namespace Invert911_WebSite.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            this.UserName.Focus();

            if (Request.Params["Login"] == "Success")            
            {
                StatusLabel.Text = "Successfully created user.  Please login using your new user name and password.";

            }

        }

        protected void LoginButton_Click(Object sender, EventArgs e)
        {
            LoginMessage LoginMsg = new LoginMessage();
            LoginMsg.UserName = this.UserName.Text;
            LoginMsg.Password = Password.Text;

            //i9MessageManager.mIi9MessageManager = new InvertService.BusinessLib.i9MessageManagerBLL();
            i9Message responseMsg = i9MessageManagerBLL.SendMessage(MobileMessageType.Admin, AdminType.Login, "LoginPage", LoginMsg.GetType(), LoginMsg);

            if (responseMsg.ErrorStatus.IsError)
            {
                FailureText.Text = responseMsg.ErrorStatus.ErrorMsg;
                return;
            }

            if (responseMsg.MsgBodyDataSet.Tables[0].Rows.Count <= 0)
            {
                FailureText.Text = "Wrong user name or password, please try again.";

                return;
            }

            //Go To Main Window
            Session.Add("Login", "true");
            Session.Add("Badge", responseMsg.MsgBodyDataSet.Tables["i9SysPersonnel"].Rows[0]["BadgeNumber"].ToString());
            Session.Add("LoginDataSet", responseMsg.MsgBodyDataSet);
            
            Response.Redirect("~/");
        }
    }
}
