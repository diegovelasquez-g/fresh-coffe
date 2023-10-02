using CFS.BAL.Contracts;
using CFS.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace CFS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] NewUserRequestDto newNewUser)
        {
            var result = await _userService.CreateUserAsync(newNewUser);
            if(result)
                return Ok("Usuario registrado con éxito.");
            return BadRequest("Ha ocurrido un error, no se pudo registrar el usuario.");
        }

        [HttpPut]
        [Route("UpdateUser/{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] EditUserRequestDto updatedNewUser)
        {
            var result = await _userService.UpdateUserAsync(userId, updatedNewUser);
            if(result)
                return Ok("Usuario actualizado con éxito.");
            return BadRequest("Ha ocurrido un error, no se pudo actualizar el usuario.");
        }

        [HttpDelete]
        [Route("ChangeUserStatus/{userId}")]
        public async Task<IActionResult> ChangeUserStatus(int userId)
        {
            var result = await _userService.ChangeUserStatus(userId);
            if(result)
                return Ok("Se ha cambiado el estado del usuario.");
            return BadRequest("Ha ocurrido un error, no se pudo cambiar el estado del usuario.");
    }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto userCredentials)
        {
            var result = await _userService.LoginAsync(userCredentials);
            if(result)
                return Ok("Usuario autenticado con éxito.");
            return BadRequest("Contraseña o email incorrecto.");
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            return Ok(result);
        }
    }
}
