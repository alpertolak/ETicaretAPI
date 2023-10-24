using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Absractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int ExpireSecond, AppUser appUser);
        string CreateRefreshToken();
    }
}
