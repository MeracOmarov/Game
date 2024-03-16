using Domen.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abtraction
{
    public  interface IUserMatchHistory
    {
        Task<List<string>> FetchUserMatchHistory(int selectedUserId);
    }
}
