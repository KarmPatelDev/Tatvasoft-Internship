using Data_Access_Layer.Entity;
using Data_Access_Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business_Logic_Layer;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public BALLogin _balLogin;

        public LoginController(BALLogin balLogin)
        {
            _balLogin = balLogin;
        }

        ResponseResult result = new ResponseResult();
        [HttpPost]
        public ResponseResult LoginUser(User user)
        {
            try
            {
                result.Data = _balLogin.LoginUser(user);
                result.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Result = ResponseStatus.Error;
            }
            return result;
        }
    }
}
