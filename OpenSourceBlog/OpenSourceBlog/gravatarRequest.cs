using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;

namespace OpenSourceBlog
{
    public class gravatarRequest
    {
        private string email;
        private string url = "http://www.gravatar.com/avatar.php?gravatar_id=";

        public gravatarRequest(string email)
        {
            this.email = email;
        }

        //void for now
        public void getGravatar()
        {
            //create md5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(email);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                email = sb.ToString();
                url += email;
            }

            HttpPostRequest();
        }

        private void HttpPostRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            //TODO handle PNG image response
        }
    }
}