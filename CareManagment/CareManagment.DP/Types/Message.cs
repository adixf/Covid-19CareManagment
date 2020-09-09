using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP.Types
{
    public class Message
    {
        public Message(string header, string content, bool isOpen)
        {
            Header = header;
            Content = content;
            IsOpen = isOpen;
        }
        public string Header { get; set; }
        public string Content { get; set; }
        public bool IsOpen { get; set; }
    }
}
