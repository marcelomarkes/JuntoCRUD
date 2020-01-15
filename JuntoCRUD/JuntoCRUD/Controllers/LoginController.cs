using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using JuntoCRUD.Business.Models;
using JuntoCRUD.Infra;
using JuntoCRUD.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JuntoCRUD.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody]Usuario usuario,
            [FromServices]UsuarioRepository usuarioRepository,
            [FromServices]AuthConfiguration authConfiguration,
            [FromServices]TokenConfiguration tokenConfiguration)
        {
            bool validCredentials = false;
            if(usuario != null && !String.IsNullOrWhiteSpace(usuario.LoginUsuario))
            {
                var usuarioTemp = usuarioRepository.Listar();
                validCredentials = (usuarioTemp != null && usuario == usuarioTemp);
            }
            if (validCredentials)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.LoginUsuario, "LoginUsuario"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.LoginUsuario)
                    }
                );

                DateTime createDate = DateTime.Now;
                DateTime expireDate = createDate +
                    TimeSpan.FromSeconds(tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfiguration.Issuer,
                    Audience = tokenConfiguration.Audience,
                    SigningCredentials = authConfiguration.SigningCredentials,
                    Subject = identity,
                    NotBefore = createDate,
                    Expires = expireDate
                });

                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = expireDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
}