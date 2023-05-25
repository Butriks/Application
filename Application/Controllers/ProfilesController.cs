using Application.Database;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Application.Controllers
{
    [ApiController]
    [Route("profile")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesTable _profiles;


        public ProfilesController(ProfilesTable profiles)
        {
            _profiles = profiles;
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

            try
            {   string str = Convert.ToBase64String(human.photo);
                byte[] newByteArray = Convert.FromBase64String(str);

                string result = $"$${human.name}$${human.information}$${human.age}$${str}$$";

                return result;
            }
            catch {
                return "-1";
            }
            
        }

        [HttpGet]
        [Route("check-gender")]
        public bool CheckGender(int userId)
        {
            bool findedUser = _profiles.GetGender(userId);

            return true;
        }

        /*public bool CheckExistUser(int userId)
        {
            string query = $"SELECT COUNT(*) FROM profiles WHERE user_id = {userId}";
            int count = Convert.ToInt32(db.ExecuteScalar(query));
            if (count == 0)
            {
                return false;
            }
            else { return true; }
        }*/

        [HttpGet]
        [Route("check-exist-user")]
        public bool CheckExist(int userId)
        {
            bool findedUser = _profiles.CheckExistUser(userId);

            return true;
        }

    }
}
