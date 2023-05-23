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

            string str = Convert.ToBase64String(human.photo);
            byte[] newByteArray = Convert.FromBase64String(str);

            string result = $"$${human.name}$${human.information}$${human.age}$${str}$$";

            return result;
        }

    }
}
