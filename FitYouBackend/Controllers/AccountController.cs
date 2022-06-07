using FitYouBackend.Models;
using FitYouBackend.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FitYouBackend.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        private FityouContext db = new FityouContext();

        [Route("api/login")]
        [HttpPost]
        public IHttpActionResult Login(User user)
        {

            List<User> users = db.User.ToList();

            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User dbUser = users.Find(p => p.Username == user.Username);

            if (dbUser == null)
            {
                return Ok(new
                {
                    token = "",
                    username = "Not found"
                }); 
            }

            if (dbUser.Password != user.Password)
            {
                return Ok(new
                {
                    token = "",
                    username = "Not authorized"
                });
            }

            

            var token = TokenGenerator.GenerateTokenJwt(user.Username);
            return Ok(new
            {
                token = token,
                username = user.Username
            }); ;

        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            if (expires != null)
            {
                if (DateTime.UtcNow < expires) return true;
            }
            return false;
        }

        [Route("api/validate")]
        [HttpGet]
        //sadasd
        public IHttpActionResult ValidateToken(HttpRequestMessage request)
        {

            try
            {
                var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
                var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
                var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
                var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));

                SecurityToken securityToken;
                var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidAudience = audienceToken,
                    ValidIssuer = issuerToken,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = LifetimeValidator,
                    IssuerSigningKey = securityKey
                };

                string token = "";
                IEnumerable<string> authzHeaders;
                if (!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1)
                {
                    return null;
                }
                var bearerToken = authzHeaders.ElementAt(0);
                token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
                

                tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                var jwtToken = (JwtSecurityToken)securityToken;

                var username = jwtToken.Claims.ElementAt(0).ToString();

                username = username.Substring(13);

                string newToken = TokenGenerator.GenerateTokenJwt(username);

                return Ok(new { 
                token = newToken,
                username = username
                });
            }
            catch
            {
                return null;
            }

        }
    }
}

