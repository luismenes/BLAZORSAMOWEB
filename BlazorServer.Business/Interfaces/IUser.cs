using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Business.Interfaces
{
    public interface IUser
    {
        Task<bool> IsLoggedIn(long userId, string keySession);

    }
}
