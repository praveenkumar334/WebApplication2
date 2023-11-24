using MailKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Org.BouncyCastle.Asn1.Pkcs;
using WebApplication2.Models;

namespace WebApplication2.Services
{

    public class MailService : IEMailService
    {
        private readonly IConfiguration _configuration;
        public MailService(IConfiguration configuration)
        {
           
            _configuration = configuration;
          
        }

        public bool SendMail(MailRequest mailData)
        {
            try
            {
               var _mailSettings = GetMailSettings();
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress(_mailSettings.SenderName, _mailSettings.SenderEmail);
                    emailMessage.From.Add(emailFrom);
                    MailboxAddress emailTo = new MailboxAddress(mailData.EmailToName, mailData.EmailToId);
                    emailMessage.To.Add(emailTo);

                    emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
                    emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));

                    emailMessage.Subject = mailData.EmailSubject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.TextBody = mailData.EmailBody;

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();
                    //this is the SmtpClient from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        mailClient.Connect(_mailSettings.Server,Convert.ToInt32(_mailSettings.Port), MailKit.Security.SecureSocketOptions.StartTls);
                        mailClient.Authenticate(_mailSettings.UserName, _mailSettings.Password);
                        mailClient.Send(emailMessage);
                        mailClient.Disconnect(true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // Exception Details
                return false;
            }
        }

        private MailSettings GetMailSettings()
        { 
         MailSettings mailSettings = new MailSettings();
            mailSettings.Server = _configuration["MailSettings:Server"];
            mailSettings.SenderEmail = _configuration["MailSettings:SenderEmail"];
            mailSettings.SenderName = _configuration["MailSettings:SenderName"];
            mailSettings.Port =Convert.ToInt32( _configuration["MailSettings:Port"]);
            mailSettings.UserName = _configuration["MailSettings:UserName"];
            mailSettings.Password = _configuration["MailSettings:Password"];
            return mailSettings;
        }
    }
}

