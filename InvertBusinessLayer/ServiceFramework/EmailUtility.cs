using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using Invert911.InvertCommon.Utilities;

namespace InvertService.ServiceFramework
{
    class EmailUtility
    {

        public static bool SendEmail(string ToEmail, string FromEmail, string EmailSubject, string EmailBody)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(
                new MailAddress(FromEmail), new MailAddress(ToEmail));

            message.Subject = EmailSubject;
            message.Body = EmailBody;

            string SMTPServerAddress = ConfigurationManager.Instance.SMTPServerAddress;
            string SMTPUserName = ConfigurationManager.Instance.SMTPUserName;
            string SMTPPassword = ConfigurationManager.Instance.SMTPPassword;
            string SMTPPort = ConfigurationManager.Instance.SMTPPort;

            SmtpClient client = new SmtpClient(SMTPServerAddress, int.Parse(SMTPPort));
            if (String.IsNullOrEmpty(SMTPUserName) == false)
            {
                client.Credentials = new System.Net.NetworkCredential(SMTPUserName, SMTPPassword);
            }
            client.Send(message);

            return true;
        }
    }
}
