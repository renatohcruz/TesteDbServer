using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Entrada;
using Teste.Domain.Repositorios;
using Teste.Shared;
using Teste.Shared.Saida;

namespace Teste.Api.Controllers
{
    public class LoginController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public LoginController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("v1/Login")]
        public async Task<ISaidaResultado> Post([FromBody]LoginEntrada entrada)
        {
            if(await _clienteRepositorio.ValidaCliente(entrada.CPF, entrada.Senha))
            {
                var claims = new[]
                {
                     new Claim(ClaimTypes.SerialNumber, entrada.CPF)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.SecurityKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                     issuer: "Teste",
                     audience: "Teste",
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: creds);

                var tokenGerado = new JwtSecurityTokenHandler().WriteToken(token);
                return await Task.FromResult(new SaidaResultado(true, "Token gerado.", tokenGerado));
            }

            return await Task.FromResult(new SaidaResultado(false, "CPF ou senha incorreto.", null));
        }
    }
}
