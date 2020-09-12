using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareManagment.DP.Types
{
    public class Message
    {
        public Message(string header, string content, bool isSuccess, bool isError)
        {
            Header = header;
            Content = content;
            IsSuccess = isSuccess;
            IsError = isError;
            
        }
        public string Header { get; set; }
        public string Content { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
    }
}
