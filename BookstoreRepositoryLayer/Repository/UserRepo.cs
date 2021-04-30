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
    public class UserRepo : IUserRepo
    {
        private readonly UserContext userDbContext;
        private readonly IConfiguration configuration;
        public UserRepo(UserContext userDbContext, IConfiguration configuration)
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
            try
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
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public UserRegistration AddUser(UserRegistration objCustomer)
        {
            try
            {
                string encodePassword = PasswordEncryption(objCustomer.password);
                objCustomer.password = encodePassword;
                this.userDbContext.UserDB.Add(objCustomer);
                var result = this.userDbContext.SaveChanges();
                if (result != 0)
                {
                    return objCustomer;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error while AddUser " + e.Message);
            }
        }

        public IEnumerable<UserRegistration> GetAllUser()
        {
            try
            {
                var result = this.userDbContext.UserDB.ToList<UserRegistration>();
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error while Getting_All_Users " + e.Message);
            }
        }
        public UserRegistration Login(UserLogin login)
        {
            try
            {
                var result = this.userDbContext.UserDB.Where<UserRegistration>(details => details.email == login.email).FirstOrDefault();
                if (result != null)
                {
                    string decryptPassword = Decryptdata(result.password);
                    if (decryptPassword == login.password)
                        return result;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error while Login User " + e.Message);
            }
        }
        public string ForgetPassword(ForgetPassword forget)
        {
                string subject = "Reset Password link is provided below click on the link";
                // string body="Hello Dear user link will be provided from frontend";
                var result = this.userDbContext.UserDB.Where<UserRegistration>(user => user.email == forget.email).FirstOrDefault();
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
