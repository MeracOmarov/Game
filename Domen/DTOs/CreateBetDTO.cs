using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.DTOs
{
    public class CreateBetDTO
    {
        public int IdofMatchHistory {  get; set; }

        public string OneUserBet { get; set; }

        public string AnotherUserBet { get; set; }

        public string Winner {  get; set; }
    }
}
