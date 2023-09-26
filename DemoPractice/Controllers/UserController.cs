using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Team.Data.Model;
using Team.Services;

namespace DemoPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _iUserService;
        public UserController(IUserService iuserservice)
        {
            _iUserService = iuserservice;
        }

        [HttpPost("AddPlayer")]
        public IActionResult AddUser(User user)
        {
            var returnData = new Response<object>();
            try
            {

                if (!ModelState.IsValid)
                {
                    returnData.IsSuccess = false;
                    returnData.InfoMessage = "Invalid data";
                    returnData.Data = ModelState;
                }
                int res = _iUserService.AddUser(user);
                if (res == 1)
                {
                    returnData.IsSuccess = true;
                    returnData.InfoMessage = "Player added successfully";
                    return Ok(returnData);
                }
                else if (res == 2)
                {
                    returnData.IsSuccess = false;
                    returnData.InfoMessage = "Player not added successfully";
                    return Ok(returnData);
                }
                else if (res == 3)
                {
                    returnData.IsSuccess = false;
                    returnData.InfoMessage = "15 Player limit exceded";
                    return Ok(returnData);
                }
                else if (res == 4)
                {
                    returnData.IsSuccess = false;
                    returnData.InfoMessage = "Player Email Id already exist";
                    return Ok(returnData);
                }
                else
                {
                    returnData.IsSuccess = false;
                    returnData.InfoMessage = "Please contact admin";
                    return Ok(returnData);
                }

            }
            catch (Exception ex)
            {

                returnData.IsSuccess = false;
                returnData.InfoMessage = "Please contact admin";
                returnData.Data = ex.Message;
                return Ok(returnData);

            }

        }

        [HttpGet("ShowAllPlayer")]
        public List<User> GetAllPlayers()
        {
            return _iUserService.GetAllPlayer();
        }



    }
}
