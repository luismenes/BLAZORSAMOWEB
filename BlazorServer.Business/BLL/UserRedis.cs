using BlazorServer.Business.Interfaces;
using BlazorServer.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Business.BLL
{
    internal class UserRedis : IUser
    {
        private readonly SamoContext _samoContext;
        public UserRedis()
        {
            _samoContext = new SamoContext();
        }
        public async Task<bool> IsLoggedIn(long userId, string keySession)
        {
            if (!long.TryParse(keySession, out long keySessionLong))
            {
                return false;
            }
            var isLoggedIn = await _samoContext.Users.AnyAsync(x => x.Id == userId && x.OperacionId == keySessionLong && x.Estado == true);
            return isLoggedIn;
        }
    }
}
