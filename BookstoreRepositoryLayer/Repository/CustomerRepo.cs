using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reactive.Subjects;
using System.Text;

namespace BookstoreRepositoryLayer.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly UserContext userDbContext;
        private readonly IConfiguration configuration;
        public CustomerRepo(UserContext userDbContext, IConfiguration configuration)
        {
            this.userDbContext = userDbContext;
            this.configuration = configuration;
        }
        public string PasswordEncryption(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = Encoding.UTF8.GetBytes(password);
                string encodedPassword = Convert.ToBase64String(encData_byte);
                return encodedPassword;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public static string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }

        public CustomerRegistration AddCustomer(CustomerRegistration objCustomer)
        {
            string encodePassword = PasswordEncryption(objCustomer.password);
            objCustomer.password = encodePassword;
            this.userDbContext.CustomerRegister.Add(objCustomer);
            var result = this.userDbContext.SaveChanges();
            if (result != 0)
            {
                return objCustomer;
            }
            return null;
        }

        public IEnumerable<CustomerRegistration> GetAllCustomer()
        {
            var result = this.userDbContext.CustomerRegister.ToList<CustomerRegistration>();
            return result;
        }
        public CustomerRegistration Login(CustomerLogin login)
        {
            var result = this.userDbContext.CustomerRegister.Where<CustomerRegistration>(details => details.email == login.email).FirstOrDefault();
            if (result != null)
            {
                string decryptPassword = Decryptdata(result.password);
                if (decryptPassword == login.password)
                    return result;
            }
            return null;
        }
        public string ForgetPassword(ForgetPassword forget)
        {
            string subject = "Reset Password link is provided below click on the link";
           // string body="Hello Dear user link will be provided from frontend";
            var result = this.userDbContext.CustomerRegister.Where<CustomerRegistration>(user => user.email == forget.email).FirstOrDefault();
            if (result != null)
            {
                string decode = Decryptdata(result.password);
                using (MailMessage mailMessage = new MailMessage("sandeepgaurdec13@gmail.com", forget.email))
                {
                    mailMessage.Subject = subject;
                    mailMessage.Body = decode;
                    mailMessage.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("sandeepgaurdec13@gmail.com", "sANDEEP123@");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mailMessage);
                    return "Success";
                }

            }
            return "Error";
        }
    }
}
