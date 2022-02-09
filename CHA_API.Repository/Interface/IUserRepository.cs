using CHA_API.Model.RequestModel;
using CHA_API.Model.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHA_API.Repository
{
    public interface IUserRepository
    {
        Task<UserLoginMaster> AuthenticateUser(UserLoginRequest userLoginRequest);
    }
}
