using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using MiniBlog.Model;
using MiniBlog.Services;
using MiniBlog.Stores;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserStore userStore;
        private readonly IArticleStore articleStore;
        private readonly UserService userService;
        public UserController(IUserStore userStore, IArticleStore articleStore, UserService userService)
        {
            this.userStore = userStore;
            this.articleStore = articleStore;
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Register(User user)
        {
            userService.RegisterUser(user);
            return CreatedAtAction(nameof(Register), new { name = user.Name }, user);
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return userStore.Users;
        }

        [HttpPut]
        public User Update(User user)
        {
            return userService.UpdateUser(user);
        }

        [HttpDelete]
        public User Delete(string name)
        {
            return userService.DeleteUser(name);
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return userStore.Users.FirstOrDefault(_ => _.Name.ToLower() == name.ToLower());
        }
    }
}