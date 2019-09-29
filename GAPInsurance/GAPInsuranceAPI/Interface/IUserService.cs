using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAPInsuranceAPI.Interface
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
