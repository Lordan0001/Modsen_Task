using Library.Application.Dto;
using Library.Application.Interfaces;
using Library.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
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

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDTO userDTO)
        {
            var newUser =await _userService.Registration(userDTO);
            return Ok(newUser);
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<ActionResult> Authenticate(UserDTO userDTO)
        {
            var token = await _userService.Login(userDTO);
            return Ok(token);
        }
    }
}
