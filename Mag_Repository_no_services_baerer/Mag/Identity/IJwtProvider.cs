using Mag.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Identity
{
        public interface IJwtProvider
        {
                string GenerateJwtToken(User user);
        }
}
