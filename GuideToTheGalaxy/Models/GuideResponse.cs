using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideToTheGalaxy.Models
{
    public class GuideResponse
    {
        public GuideResponse()
        {

        }

        public GuideResponse(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }

        public static GuideResponse Empty
        {
            get
            {
                return new GuideResponse() { Message = string.Empty };
            }
        }

        public static GuideResponse Unknown
        {
            get
            {
                return new GuideResponse() { Message = "I have no idea what you are talking about" };
            }
        }
    }
}
