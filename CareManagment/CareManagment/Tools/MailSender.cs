using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.Tools
{
    public class MailSender
    {

        public void SendMail(string to, string subject, string body)
        {

            MailMessage message = new MailMessage();
            message.Subject = subject; 
            message.From = new MailAddress("Covid19caremanagment@gmail.com");
            message.Body = body;
            message.To.Add(to);
            SmtpClient smtp = new SmtpClient("smtp.Gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("Covid19caremanagment@gmail.com","covid19123");
            smtp.EnableSsl = true;
           
            smtp.Port = 587;
            smtp.Send(message);

        }
    }
}
