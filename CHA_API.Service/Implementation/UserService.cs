using CHA_API.Model.RequestModel;
using CHA_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CHA_API.Model.ExceptionModel;
using CHA_API.Model.TableModel;
using CHA_API.Model;

namespace CHA_API.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public UserService(IUserRepository userRepository,
                           IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<ResponseModel<string>> AuthenticateUser(UserLoginRequest userLoginRequest)
        {
            try
            {
                ResponseModel<string> response = new ResponseModel<string>();
                string token = String.Empty;
                UserLoginMaster userLogin = await _userRepository.AuthenticateUser(userLoginRequest);
                if (userLogin != null)
                {
                    token = await _jwtTokenService.GenerateToken(userLogin.UserName);
                }
                response.Data = token;
                response.IsSuccessful = !string.IsNullOrEmpty(token);
                return response;
            }
            catch (UnhandledException) { throw; }
            catch (Exception ex)
            {
                throw new UnhandledException(ex.Message, ex.InnerException, "UserService", "AuthenticateUser", userLoginRequest);
            }
        }
    }
}
