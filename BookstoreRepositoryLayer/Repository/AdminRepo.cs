using BookstoreModelLayer;
using BookstoreRepositoryLayer.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRepositoryLayer.Repository
{
   public  class AdminRepo:IAdminRepo
    {
        private readonly UserContext userDbContext;
        private readonly IConfiguration configuration;
        public AdminRepo(UserContext userDbContext, IConfiguration configuration)
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

        public AdminRegistration AddAdmin(AdminRegistration objAdmin)
        {
            string encodePassword = PasswordEncryption(objAdmin.password);
            objAdmin.password = encodePassword;
            this.userDbContext.AdminDB.Add(objAdmin);
            var result = this.userDbContext.SaveChanges();
            if (result != 0)
            {
                return objAdmin;
            }
            return null;
        }
    }
}
