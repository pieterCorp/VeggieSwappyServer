using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwappyServer.Business.Dto;
using VeggieSwappyServer.Business.Services;

namespace VeggieSwappyServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("AllUserTradeItems")]
        public async Task<IEnumerable<UserTradeItemDto>> GetAllUserTradeItems()
        {
            var test = await _userService.GetAllUserTradeItemssAsync();
           
            return test;
        }

        [HttpGet]
        public async Task<IEnumerable<object>> GetAllUsersAsync()
        {
            return await _userService.GetAllUsersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserAsync(int id)
        {
            return Ok(await _userService.GetUserAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUserAsync(int id)
        {
            return Ok(await _userService.DeleteEntityAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(UserDto model)
        {
            return Ok(await _userService.AddEntityAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync(UserDto model)
        {
            return Ok(await _userService.UpdateEntityAsync(model));
        }
    }
}
