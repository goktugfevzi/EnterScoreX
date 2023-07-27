using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ContactUsDTOs
{
    public class SendMessageDto
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string SubjectTitle { get; set; }
        public string MessageBody { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}
