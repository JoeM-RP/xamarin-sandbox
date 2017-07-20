using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandbox.Services
{
    public interface IRoomsService
    {
        Task<List<object>> GetRoomDirectory(string geography);
    }
}
