using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public class UserService
    {
        private readonly IUserStore userStore;
        private readonly IArticleStore articleStore;

        public UserService(IUserStore userStore, IArticleStore articleStore)
        {
            this.userStore = userStore;
            this.articleStore = articleStore;
        }

        public void RegisterUser(User user)
        {
            if (!userStore.Users.Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
            {
                userStore.Users.Add(user);
            }
        }

        public User UpdateUser(User user)
        {
            var foundUser = userStore.Users.FirstOrDefault(_ => _.Name == user.Name);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }

        public User DeleteUser(string name)
        {
            var foundUser = userStore.Users.FirstOrDefault(_ => _.Name == name);
            if (foundUser != null)
            {
                userStore.Users.Remove(foundUser);
                articleStore.Articles.RemoveAll(a => a.UserName == foundUser.Name);
            }

            return foundUser;
        }
    }
}
