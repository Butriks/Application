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

        public UserController(UsersTable usersTable, ProfilesTable p)
        {
            _usersTable = usersTable;
            _profiles = p;
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

        [HttpGet]
        [Route("check-user-pass")]
        public bool CheckPass(string pas, int id)
        {
            bool findedUser = _usersTable.CheckPassword(pas, id);

            return findedUser;
        }

        [HttpGet]
        [Route("get-user-info")]
        public string get_info(int id)
        {
            Human human = new Human();
            human.photo = _profiles.GetPhoto(id);
            human.name = _profiles.GetFirstName(id);
            human.information = _profiles.GetInterests(id);
            human.age = _profiles.GetAge(id);

            return "azazaz";
        }
    }
}