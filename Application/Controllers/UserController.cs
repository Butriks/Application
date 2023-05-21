using Application.Database;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UsersTable _usersTable;
        private readonly ProfilesTable _profiles;

        public UserController(UsersTable usersTable)
        {
            _usersTable = usersTable;
        }

        [HttpGet]
        [Route("emails")]
        public async Task<IEnumerable<UserEmail>> GetAllEmailsAsync()
        {
            await Task.Delay(2000);

            return new List<UserEmail>
        {
            new UserEmail
            {
                Email = "test@mail.ru"
            }
        };
        }

        [HttpGet]
        [Route("get-by-id")]
        public string GetUserById(int userId)
        {
            string? findedUser = _usersTable.GetUser(userId);

            return findedUser;
        }

        [HttpGet]
        [Route("check-username")]
        public bool CheckUserName(string username)
        {
            var status = _usersTable.CheckUserName(username);

            return status;
        }

        [HttpPost]
        [Route("add-user")]
        public bool AddUser(string username, string email, string password)
        {
            try
            {
                _usersTable.AddUser(username, email, password);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("check-gender")]
        public bool CheckGender(int userId)
        {
            bool findedUser = _profiles.GetGender(userId);

            return findedUser;
        }

        [HttpGet]
        [Route("get-user-id")]
        public int CheckID(string username)
        {
            int findedUser = _usersTable.GetUserId(username);

            return findedUser;
        }
    }
}