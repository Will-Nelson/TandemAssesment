using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TandemAssesment.Model;

namespace TandemAssesment.Interface
{
    public interface IRepositoryUserFactory 
    {
        UserModel Convert(UserSaveModel user);
    }
}
