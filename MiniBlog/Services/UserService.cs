using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class UserService
    {
        private readonly IUserStore userStore;

        public UserService(IUserStore userStore)
        {
            this.userStore = userStore;
        }
    }
}
