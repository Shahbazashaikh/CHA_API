using System.Threading.Tasks;

namespace CHA_API.Service
{
    public interface IJwtTokenService
    {
        Task<string> GenerateToken(string userName);
    }
}
