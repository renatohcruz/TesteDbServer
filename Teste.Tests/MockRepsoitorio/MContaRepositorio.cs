using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Entidades;
using Teste.Domain.Repositorios;

namespace Teste.Tests.MockRepsoitorio
{
    class MContaRepositorio : IContaRepositorio
    {
        public ContaCorrente conta { get; private set; }

        public async Task Atualiza(ContaCorrente contaCorrente)
        {
            conta = contaCorrente;
            await Task.CompletedTask; ;
        }

        public async Task<ContaCorrente> Busca(int numeroConta)
        {
            return await Task.FromResult(new ContaCorrente(numeroConta, 100));
        }
    }
}
