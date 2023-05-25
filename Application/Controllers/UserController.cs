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
        public bool AddUserA(string username, string email, string password)
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

        /*public string GetAllUsers()
    {
        string query = "SELECT * FROM users";
        MySqlDataReader reader = db.ExecuteReader(query);

        StringBuilder sb = new StringBuilder();


        while (reader.Read())
        {
            int userId = reader.GetInt32(0);
            string username = reader.GetString(1);
            string email = reader.GetString(2);
            //string password = reader.GetString(3);

            //sb.AppendLine($"User ID: {userId}, Username: {username}, Email: {email}, HeshPass: {password}");
            sb.AppendLine($"User ID: {userId}, Username: {username}, Email: {email}");
        }

        DB.CloseDataReader(reader);

        return sb.ToString();
    }*/

        [HttpGet]
        [Route("get-all-users")]
        public string GetAll()
        {
            List<int> result = _usersTable.GetAllUsersId();
            string resultString = string.Join(", ", result);
            return resultString;

        }
    }
}