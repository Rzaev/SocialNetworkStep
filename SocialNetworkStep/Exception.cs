using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkStep
{
    class NullException : ArgumentException
    {
        public NullException(string text, DateTime timeException, int errorLine, string source)
        {
            Text = text;
            TimeException = timeException;
            ErrorLine = errorLine;
            Source = source;
        }

        public string Text { get; set; }
        public DateTime TimeException { get; set; }
        public int ErrorLine { get; set; }
        public string Source { get; set; }

        public void Show()
        {
            Console.WriteLine(Text);
            Console.WriteLine(TimeException);
            Console.WriteLine("Error Line:" + ErrorLine);
            Console.WriteLine("Source" + Source);
        }
    }
}

