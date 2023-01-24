using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MediaFaire.Helper
{
    public class MailHelper : IMailHelper
    {
        private readonly IConfiguration configuration;

        public MailHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void SendMail(InputEmail inputEmail)
        {
            /* using (System.Net.Mail.SmtpClient s = new SmtpClient(configuration.GetValue<string>("Mail:Host"), configuration.GetValue<int>("Mail:Port")))
             {
                 var msg = new System.Net.Mail.MailMessage();

                 msg.To.Add(inputEmail.Email);
                 msg.Subject = inputEmail.Subject;
                 msg.Body = inputEmail.Message;
                 msg.From=new MailAddress(configuration.GetValue<string>("Mail:From"), configuration.GetValue<string>("Mail:Sender"),System.Text.Encoding.UTF8);

                 s.Credentials = new System.Net.NetworkCredential(configuration.GetValue<string>("Mail:From"), configuration.GetValue<string>("PWD"));

                 s.Send(msg);

             }
            */
            try
            {
                MailMessage msg = new MailMessage();
               
                msg.To.Add(inputEmail.Email);
               
                MailAddress address = new MailAddress("ahmedalnasr22@gmail.com");
    
                msg.From = address;
                msg.Subject =inputEmail.Subject;
                msg.Body =inputEmail.Message;

                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 25;

                NetworkCredential credentials = new NetworkCredential("ahmedalnasr22@gmail.com", "01225480925");
                client.UseDefaultCredentials = true;
                client.Credentials = credentials;

      
                client.Send(msg);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               
            }
        }
    }
}
