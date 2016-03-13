using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinaLogin
{
    public class Weibo
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Weibo(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
