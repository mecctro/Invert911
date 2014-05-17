using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Invert911_WebSite
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsSessionLogin)
            {
                BadgeNumberLabel.Visible = true;
                string BadgeNumber = (string)Session["Badge"];
                BadgeNumberLabel.Text = "User:  " + BadgeNumber + "<BR />";
                LoginPageButton.Text = "Logout";
                
            }
            else
            {
                BadgeNumberLabel.Text = "";
                BadgeNumberLabel.Visible = false;
                LoginPageButton.Text = "Login";
            }
        }

        public bool IsSessionLogin
        {
            get
            {
                bool SessionLogin = false;
                try
                {
                    if ((string)Session["Login"] == "true")
                    {
                        SessionLogin = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error:  " + ex.Message);
                }
                return SessionLogin;

            }
        }

        public void LoginPageButton_OnClick(Object sender, EventArgs e)
        {
            if (LoginPageButton.Text == "Login")
            {
                Response.Redirect("~/Account/Login.aspx");
            }
            else
            {
                Session["Login"] = "false";
                Response.Redirect("~/");
            }
        }

    }
}
