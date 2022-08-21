using Business.Abstract;
using Core.Utilities.Results;
using Entities;
using Entities.Dto;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Net.Mail;
using System.Text;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace Business.Concrete
{
    internal class MailManager : IMailService
    {
        private IConfiguration _configuration;
        private readonly MailSettings _mailSettings;

        public MailManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _mailSettings = configuration.GetSection("MailSettings").Get<MailSettings>();
        }

      
        public void SendMail(Mail mail)
        {
            //MimeMessage email = new();

            //email.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));

            //email.To.Add(new MailboxAddress(mail.ToFullName, mail.ToEmail));

            //email.Subject = mail.Subject;

            //string mails = "<table>" +
            //    "   < tr >" +
            //    "< th > Staff Name </ th >" +
            //    "< th > Client Name </ th >" +
            //    "< th > Monday </ th >" +
            //    "< th > From Date </ th >" +
            //    "< th > To Date </ th >" +
            //    "< th > From Time </ th >" +
            //    "< th > To Time </ th >" +
            //    "< th > Total hours </ th >" +
            //    "</ tr >" +
            //    "< tr >" +
            //    "< td > Abc </ td >" +
            //    "< td > Xyz </ td >" +
            //    "< td > Monday </ td >" +
            //    "< td > 10 / 30 / 2018 </ td >" +
            //    "< td > 11 / 6 / 2018 </ td >" +
            //    "< td > 2:30 PM </ td >" +
            //    "< td > 6:30 PM </ td >" +
            //    "< td > 04:00:00 </ td >" +
            //    "</ tr >" +
            //    "</ table > ";
            //BodyBuilder bodyBuilder = new()
            //{
            //    TextBody = mail.TextBody,
            //    //HtmlBody = mail.HtmlBody
            //    HtmlBody=mails
            //};

            //if (mail.Attachments != null)
            //    foreach (MimeEntity? attachment in mail.Attachments)
            //        bodyBuilder.Attachments.Add(attachment);

            //email.Body = bodyBuilder.ToMessageBody();

            //using SmtpClient smtp = new();            
            //smtp.Connect(_mailSettings.Server, _mailSettings.Port);
            //smtp.Authenticate(_mailSettings.UserName, _mailSettings.Password);
            //smtp.Send(email);
            //smtp.Disconnect(true);
            string textBody = "<table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + ">" +
                "<tr bgcolor='#4da6ff'>" +
                "<td><b>Inventory Item</b></td>" +
                " <td> <b> Required Qunatity </b> </td>" +
                "</tr>";

            textBody += "</table>";
            MailMessage mail1 = new MailMessage();
            System.Net.Mail.SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail1.From = new MailAddress(_mailSettings.SenderEmail);
            mail1.To.Add(mail.ToEmail);
            mail1.Subject = "Test Mail";
            mail1.Body = mail.HtmlBody;
            mail1.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(_mailSettings.UserName, _mailSettings.Password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail1);
        }

        
    }
}
