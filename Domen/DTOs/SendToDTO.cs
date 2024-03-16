using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs
{
    public  class SendToDTO
    {
        public int FromUserID { get; set; }

        public int ToUserID { get; set; }

        public int Balance { get; set; }

    }
}
