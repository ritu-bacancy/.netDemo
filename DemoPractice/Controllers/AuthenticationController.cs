
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Team.Data.Model;
using Team.Services;

namespace DemoPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("Login")]
        public IActionResult LoginUser(LoginVM login)
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
                var user = _authenticationService.Login(login);
                if (user != null)
                {
                    returnData.IsSuccess = true;
                    returnData.InfoMessage = "Player found";
                    returnData.Data = user;
                    return Ok(returnData);
                }
                else
                {
                    returnData.IsSuccess = false;
                    returnData.InfoMessage = "User not found";
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
    }
}
