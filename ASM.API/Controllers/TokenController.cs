using ASM.Share.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        // GET: api/<TokenController>
        public IKhachhangSvc _khachhangSvc;
        public IConfiguration _configuration;
        public TokenController(IConfiguration configuration, IKhachhangSvc khachhangSvc)
        {
            _khachhangSvc = khachhangSvc;
            _configuration = configuration;
        }
        //private async Task<KhachhangSvc> GetUser(string email, string password)
        //{
        //    return _userinfor.Login(email, password);
        //}
        [HttpPost]
        public async Task<IActionResult> Post(ViewWebLogin viewWebLogin)
        {
            //List<ViewToken> list = new List<ViewToken>();
            if (viewWebLogin != null && !string.IsNullOrEmpty(viewWebLogin.Email) 
                && !string.IsNullOrEmpty(viewWebLogin.Password))
            {
                var khachhang = _khachhangSvc.Login(viewWebLogin);
                if (khachhang != null)
                {
                    if (khachhang != null)
                    {
                        //create claims details based on the user information
                        var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                            new Claim("Id", khachhang.KhachhangID.ToString()),
                            new Claim("FullName", khachhang.FullName),
                            //new Claim("LastName", khachhang.LastName),
                            //new Claim("UserName", khachhang.UserName),
                            new Claim("Email", khachhang.EmailAddress)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                            claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                        //ViewToken viewToken = new ViewToken()
                        //{
                        //    Token = new JwtSecurityTokenHandler().WriteToken(token),
                        //    KhachhangId = khachhang.KhachhangID
                        //};
                        ViewToken viewToken = new ViewToken() { Token = new JwtSecurityTokenHandler().WriteToken(token), KhachhangId = khachhang.KhachhangID };
                        return Ok(viewToken);
                        //list.Add(viewToken);
                        //return list;
                    }
                    else
                    {
                        //return list;
                        return BadRequest("Invalid credentials");
                    }
                }
                else
                {
                    //return list;
                    return BadRequest();
                }
            }
            //return list;
            return BadRequest();
        }
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        //// GET api/<TokenController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        //// POST api/<TokenController>
        ////[HttpPost]
        ////public void Post([FromBody] string value)
        ////{
        ////}

        //// PUT api/<TokenController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TokenController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
