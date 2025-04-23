using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace workZenBackend
{
	public class Service1 : IService1
	{
		public string GetData(int value)
		{
			return string.Format("You entered: {0}", value);
		}

		public CompositeType GetDataUsingDataContract(CompositeType composite)
		{
			if (composite == null)
			{
				throw new ArgumentNullException("composite");
			}
			if (composite.BoolValue)
			{
				composite.StringValue += "Suffix";
			}
			return composite;
		}

		public string sendEmailToNewUser(string userEmail , string username)
		{
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mehtabatkips@gmail.com");
                mail.To.Add(userEmail);
                mail.Subject = "Welcome to WorkZen!";
                mail.Body = $"Hi {username},\n\nYour account has been created successfully.\n\nThanks,\nWorkZen Team";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("mehtabatkips@gmail.com", "zxgu snig wass wyjm"); 
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return "Email sent successfully!";
            }
            catch (Exception ex)
            {
				return "Email failed: " + ex.Message;
            }

        }

		public string sendEmail(string userEmail)
		{

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mehtabatkips@gmail.com");
                mail.To.Add(userEmail);
                mail.Subject = "Your OTP for WorkZen!";
                mail.Body = $"Hi Mehtab ,\n\nYour account OTP is  584379.\n\nThanks,\nWorkZen Team";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("mehtabatkips@gmail.com", "teqv vzmj edlx lnia");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return "Email sent successfully!";
            }
            catch (Exception ex)
            {
                return "Email failed: " + ex.Message;
            }

        }
	}
}
