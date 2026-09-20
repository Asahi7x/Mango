using Mango.Services.AuthAPI.DTOs;
using Mango.Services.AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        protected ResponseDto _response;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequestDto)
        {
            try
            {
                var userDto = await _authService.Register(registrationRequestDto);
                _response.Result = userDto;
                _response.Message = "Usuario creado correctamente";
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.Message = ex.Message;
                return BadRequest(_response);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}
