using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkStep
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Username { get; set; } = "user";
        private string Password { get; set; } = "user12";
        public static int User_Id { get; set; } = 0;
        public int PasswordHash { get; set; } = DisplayPasswordHashCode("user12");
        //public Post[] Posts { get; set; }
        //public int PostCount { get; set; } = default;



        //public void AddPosts(ref Post post)
        //{
        //    Post[] temp = new Post[++PostCount];
        //    if (Posts != null)
        //    {
        //        Posts.CopyTo(temp, 0);
        //    }
        //    temp[temp.Length - 1] = post;
        //    Posts = temp;
        //}

        public User()
        {
            Id = ++User_Id;
        }


        private static int DisplayPasswordHashCode(string s)
        {
            int hash = s.GetHashCode();
            return hash;
        }

        public Post GetPostById(int id)
        {
            Post[] posts = new Post[3];
            return posts[id - 1];
        }

        public void ShowPostById(int id)
        {
            Post p = GetPostById(id);
            ++p.ViewCount;
            Console.WriteLine(p.Content);
        }

        public void LikePostById(int id)
        {
            Post p = GetPostById(id);
            ++p.LikeCount;
            Console.WriteLine("You like this post");
        }

        public override string ToString()
        {
            return $"ID:{Id}\nName:{Name}\nSurname:{Surname}\nAge:{Age}\nUsername:{Username}\n" +
                $"Password:{PasswordHash}";
        }
    }
}

