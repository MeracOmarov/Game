using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs
{
    public  class CreateMatchHistoryDTO
    {
        public string Name { get; set; }
        
        public string Result { get; set; }

        public string oneUserPIN { get; set; }

        public string anotherUserPIN { get; set; }

    }
}
