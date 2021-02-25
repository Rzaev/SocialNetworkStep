using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkStep
{
    class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; } = "admin";
        public string Password { get; set; } = "admin12";
        public static int Admin_Id { get; set; }
        public int PasswordHash { get; set; } = DisplayPasswordHashCode("admin12");
        public Admin()
        {
            Id = ++Admin_Id;
        }


        private static int DisplayPasswordHashCode(string s)
        {
            int hash = s.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}

