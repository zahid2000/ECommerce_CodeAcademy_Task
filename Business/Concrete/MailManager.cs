﻿using Business.Abstract;
using Core.Utilities.Results;
using Entities;
using Entities.Dto;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Net.Mail;
using System.Text;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

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
            MimeMessage email = new();

            email.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));

            email.To.Add(new MailboxAddress(mail.ToFullName, mail.ToEmail));

            email.Subject = mail.Subject;

            
            BodyBuilder bodyBuilder = new()
            {
                TextBody = mail.TextBody,
                //HtmlBody = mail.HtmlBody
                HtmlBody = mail.HtmlBody,
            };

            if (mail.Attachments != null)
                foreach (MimeEntity? attachment in mail.Attachments)
                    bodyBuilder.Attachments.Add(attachment);

            email.Body = bodyBuilder.ToMessageBody();

            using SmtpClient smtp = new();
            smtp.Connect(_mailSettings.Server, _mailSettings.Port);
            smtp.Authenticate(_mailSettings.UserName, _mailSettings.Password);
            smtp.Send(email);
            smtp.Disconnect(true);
            
        }

        
    }
}
