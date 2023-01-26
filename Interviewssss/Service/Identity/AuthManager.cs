

using DATA.DTO;
using DATA.Model;
using Interviewssss.Service.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Interviewssss.Service
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private IConfiguration _configuration;
        private ApiUser _user;
       
        public AuthManager(UserManager<ApiUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }


        public async Task<string> CreateToken() // tokin ochib berishga xizmat qiladi;
        {
            var signInCredentials = GetSignInCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(signInCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signInCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(
                Convert.ToDouble(
                    jwtSettings.GetSection("lifetime").Value));
            var token = new JwtSecurityToken(
                    issuer: jwtSettings.GetSection("Issuer").Value,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: signInCredentials
                );

            return token;
        }

        private async Task<List<Claim>> GetClaims() // claim sizni malumotlarizni saqlash uchun ishlatiladi
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, _user.UserName),
                new Claim("Id", _user.Id.ToString()),
                new Claim("Name", $"{_user.FirstName},{_user.LastName}")
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role)); // shu o1rinda "ClaimTypes.Role" o`rniga oddiygina "Role" ishlatib ketsa bo`ladi
            }

            return claims;
        }

        private SigningCredentials GetSignInCredentials() 
        {

            var key = _configuration.GetSection("Jwt").GetSection("Key").Value; // key  va jwtlarni oladi

            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)); // keyni oladi va smetric ravishta codlaydi  sekret qiladi

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);// HmacSha256 orqali  creadention qilib qaytaradi
        }

        public async Task<bool> ValidateUser(LoginDTO dto)
        {
            _user = await _userManager.FindByNameAsync(dto.Username);

            var validPassword = await _userManager.CheckPasswordAsync(_user, dto.Password);

            return (_user != null && validPassword);
        }
    }
}
