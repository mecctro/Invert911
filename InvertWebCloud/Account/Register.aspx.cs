using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Invert911.InvertCommon.Messages.Admin;
using Invert911.InvertCommon.Framework.Communication;
using InvertService.BusinessLib;

namespace Invert911_WebSite.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            if (Password.Text != ConfirmPassword.Text)
            {
                ErrorMessage.Text = "Error";

                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "RegisterUserValidationGroup";
                err.IsValid = false;
                err.ErrorMessage = "Passwords do not match";
                Page.Validators.Add(err);
                return;
            }

            CreateUserMessage CreateUserMsg = new CreateUserMessage();
            CreateUserMsg.FirstName = this.FirstName.Text;
            CreateUserMsg.LastName = this.LastName.Text;
            CreateUserMsg.Password = Password.Text;
            CreateUserMsg.Email = Email.Text;
            
            i9Message responseMsg = i9MessageManagerBLL.SendMessage(MobileMessageType.Admin, AdminType.CreateUser, "Register", CreateUserMsg.GetType(), CreateUserMsg);
            if (responseMsg.ErrorStatus.IsError)
            {
                ErrorMessage.Text = "Error";

                CustomValidator err = new CustomValidator();
                err.ValidationGroup = "RegisterUserValidationGroup";
                err.IsValid = false;
                err.ErrorMessage = responseMsg.ErrorStatus.ErrorMsg;
                Page.Validators.Add(err);

                //RegisterUserValidationSummary.
                return;
            }

            

            //if (responseMsg.MsgBodyDataSet.Tables[0].Rows.Count <= 0)
            //{
            //    ErrorMessage.Text = "Unable to create new user, please try again.";
            //    return;
            //}
            Response.Redirect(@"~\Account\Login.aspx?Login=Success");
        }
    }
}
