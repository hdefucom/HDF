using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HDF.Core.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HDF.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly TokenConfig _token;

        public AuthenticationController(TokenConfig token)
        {
            _token = token;

            
        }

        [HttpGet]
        public string Token([FromQuery] string id, [FromQuery] string pwd)
        {
            if (id != pwd)
                return null;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, id),
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_token.Secret));

            var jwtToken = new JwtSecurityToken(
                issuer: _token.Issuer,
                audience: _token.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_token.AccessExpiration),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);

        }
    }





}
