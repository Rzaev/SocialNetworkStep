using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkStep
{
    abstract class Notification
    {
        public Notification()
        {
            Id = ++Notf_Id;
        }

        public int Id { get; set; }
        public static int Notf_Id { get; set; } = 0;
        public DateTime CreatTime { get; set; }
        public string Text { get; set; }

        public abstract void PrintMessage();

    }

    class LikeNotf : Notification
    {
        public override void PrintMessage()
        {
            Console.WriteLine("Notf Info:");
            Console.WriteLine("Id:" + Id);
            Console.WriteLine("Text:" + Text);
            Console.WriteLine("Time:" + CreatTime);
        }
    }

    class ViewNotf : Notification
    {
        public override void PrintMessage()
        {
            Console.WriteLine("Notf Info:");
            Console.WriteLine("Id:" + Id);
            Console.WriteLine("Text:" + Text);
            Console.WriteLine("Time:" + CreatTime);
        }
    }

}

