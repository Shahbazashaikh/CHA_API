using CHA_API.Model.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHA_API.Service
{
    public interface IUserService
    {
        Task<string> AuthenticateUser(UserLoginRequest userLoginRequest);
    }
}
