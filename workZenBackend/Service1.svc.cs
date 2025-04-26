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

        public string sendEmailToNewUser(string userEmail, string username, string department, string designation, string dateofJoining)
        {

            
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("mehtabatkips@gmail.com");
                    mail.To.Add(userEmail);
                    mail.Subject = "Welcome to WorkZen!";
                    mail.Body = $"Hi {username} ,\n\nYour account have been Register on WorkZen as a {designation} \n\n In Department of {department}\n\n Your Date of joining is {dateofJoining}.\n\nThanks,\nWorkZen Team";

                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new NetworkCredential("mehtabatkips@gmail.com", "zmxi hakb wyuf cryg");
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
                smtp.Credentials = new NetworkCredential("mehtabatkips@gmail.com", "zmxi hakb wyuf cryg");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return "Email sent successfully!";
            }
            catch (Exception ex)
            {
                return "Email failed: " + ex.Message;
            }

        }

        public string sendLoginMailToEmployee(string userEmail)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mehtabatkips@gmail.com");
                mail.To.Add(userEmail);
                mail.Subject = "New Login to WorkZen!";
                mail.Body = $"Hi Mehtab ,\n\nYou have Successfully login to WorkZen .\n\nThanks,\nWorkZen Team";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("mehtabatkips@gmail.com", "zmxi hakb wyuf cryg");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return "Email sent successfully!";
            }
            catch (Exception ex)
            {
                return "Email failed: " + ex.Message;
            }

        }



        public string sendTaskEmail(string userEmail,string userName, string taskName, string taskDescription, string taskDeadline)
        {

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("mehtabatkips@gmail.com");
                mail.To.Add(userEmail);
                mail.Subject = "New Task Assigned !";
                mail.Body = $"Hi {userName} ,\n\nYou have been assign the {taskName}.\n\n You must have to meet the deadline {taskDeadline}. \n\n Description: {taskDescription}.\n\nThanks,\nWorkZen Team";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("mehtabatkips@gmail.com", "zmxi hakb wyuf cryg");
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
