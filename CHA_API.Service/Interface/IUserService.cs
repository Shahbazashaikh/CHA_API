using CHA_API.Model.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHA_API.Model;

namespace CHA_API.Service
{
    public interface IUserService
    {
        Task<ResponseModel<string>> AuthenticateUser(UserLoginRequest userLoginRequest);
    }
}
