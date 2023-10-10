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
            int res =  _iUserService.AddUser(user);
            if(res == 1)
            {
                returnData.IsSuccess = true;
                returnData.InfoMessage = "Player added successfully";
                return Ok(returnData);
            }
            else if(res == 2)
            {
                returnData.IsSuccess = true;
                returnData.InfoMessage = "You can not add more than 15 players.";
                return Ok(returnData);
            }
            else if (res == 3)
            {
                returnData.IsSuccess = true;
                returnData.InfoMessage = "User already exist.";
                return Ok(returnData);
            }
            else
            {
                returnData.IsSuccess = false;
                returnData.InfoMessage = "Failed to add player";
                return BadRequest(returnData);
            }

        }

        [HttpGet("ShowAllPlayer")]
        public List<User> GetAllPlayers()
        {
            return _iUserService.GetAllPlayer();
        }

        [HttpPost("SetAsCaptain")]

        public IActionResult setAsCaptain(int playerId)
        {
            int res = _iUserService.setAsCaptain(playerId);
            var returnData = new Response<object>();

            if (res == 1)
            {
                returnData.IsSuccess = true;
                returnData.InfoMessage = "Captain updated successfully.";
                return Ok(returnData);
            }else
            {
                returnData.IsSuccess = false;
                returnData.InfoMessage = "Captain not updated successfully.";
                return Ok(returnData);
            }

        }

        [HttpPost("selectTeam")]
        public int selectTeam(int[] player)
        {
            var res = _iUserService.selectTeam(player);
            return res;
        }





    }
}
