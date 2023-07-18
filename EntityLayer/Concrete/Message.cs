using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        public int MessageID{ get; set; }
        public string Subject{ get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
    }
}
