using System;
using System.Threading.Tasks;
using Common.Models;
using Common.Output;

namespace Sandbox.Services
{
    public interface IUserService
    {
        Task<Result<MeModel>> GetUserInfo();
        Task<Result<string>> GetUserPhoto();
    }
}
