using WebApplication2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Models;
using System.Net;
using Azure;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _dbcontext;

        public UserController(UserContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("GetUsers")]
        public List<User> GetUsers()
        {
            try
            {

                var users = _dbcontext.Users.ToList();

                return users;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpGet]
        [Route("GetCoachCaption")]
        public List<User> GetCoachCaption()
        {
            try
            {

                var users = _dbcontext.Users.Where(x => x.RoleId == 1 || x.RoleId == 2).ToList();

                return users;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpGet]
        [Route("CheckUser")]
        public IActionResult CheckUser(string email, string pwd)
        {
            try
            {

                var user = _dbcontext.Users.FirstOrDefault(e => e.Email == email && e.Password == pwd);

                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        [Route("AddUser")]
        public void AddUser(User user)
        {
            try
            {
                _dbcontext.Users.Add(user);
                _dbcontext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
