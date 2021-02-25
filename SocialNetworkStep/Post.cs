using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkStep
{
    class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int LikeCount { get; set; } = 0;
        public int ViewCount { get; set; } = 0;
        public static int Post_Id { get; set; } = 0;


        public Post()
        {
            Id = Post_Id;
        }



        public override string ToString()
        {
            return $"ID:{Id}\nContent:{Content}\nCreation Date:{CreationDate}" +
                $"Like Count:{LikeCount}\nView Count:{ViewCount}";
        }
    }
}

