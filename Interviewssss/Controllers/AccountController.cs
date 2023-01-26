using AutoMapper;
using DATA.DTO;
using DATA.Model;
using Interviewssss.Context;
using Interviewssss.Service.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Interviewssss.Controllers
{
  
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly UserManager<ApiUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;


        public AccountController(UserManager<ApiUser> userManager,
            ILogger<AccountController> logger,
            IMapper mapper,
            IAuthManager authManager, AppDbContext _dbContext)
        {
            dbContext = _dbContext;
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDTO userDto)
        {
            _logger.LogInformation($"Login attempt for {userDto.Username}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _authManager.ValidateUser(userDto))
            {
                return Unauthorized();
            }

            return await GetUserWithToken(userDto.Username);
        }

        [Authorize]
        [HttpGet("getme")]
        public async Task<IActionResult> GetmeAsync()
        {
            var username = User.Identity.Name;

            return await GetUserWithToken(username, hasToken: false);
        }

        private async Task<IActionResult> GetUserWithToken(string username, bool hasToken = true)
        {
            var user = await _userManager.FindByNameAsync(username);

            var roles = (await _userManager.GetRolesAsync(user)).ToArray();

            if (roles is null)
                return NotFound();

            dynamic userWithToken = MapUserWithToken(user, roles);

            userWithToken.Roles = roles;

            if (hasToken)
                userWithToken.Token = await _authManager.CreateToken();

            return Accepted(userWithToken);
        }

        private dynamic MapUserWithToken(ApiUser user, string[] role)
        {
            dynamic userWithToken = _mapper.Map<UserDTO>(user);

            return userWithToken;
        }
    }
}
