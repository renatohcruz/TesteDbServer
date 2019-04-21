using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.Domain.CasosDeUso;
using Teste.Domain.Entrada;
using Teste.Shared.Saida;

namespace Teste.Api.Controllers
{
    public class ContaCorrenteController : Controller
    {
        private readonly TranferenciaEntreContas _tranferenciaEntreContas;

        public ContaCorrenteController(TranferenciaEntreContas tranferenciaEntreContas)
        {
            _tranferenciaEntreContas = tranferenciaEntreContas;
        }

        [HttpGet]
        [Route("")]
        public async Task<ISaidaResultado> Get()
        {
            return await Task.FromResult(new SaidaResultado(true,"serviço rodando",null));
        }

        [HttpPost]
        [Authorize()]
        [Route("v1/tranferencia")]
        public async Task<ISaidaResultado> Post([FromBody]TranferenciaEntreContasEntrada entrada)
        {
            return await _tranferenciaEntreContas.executa(entrada);
        }
    }
}
