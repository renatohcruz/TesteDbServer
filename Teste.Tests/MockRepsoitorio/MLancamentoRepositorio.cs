using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Entidades;
using Teste.Domain.Repositorios;

namespace Teste.Tests.MockRepsoitorio
{
    public class MLancamentoRepositorio : ILancamentoRepositorio
    {
        public List<Lancamento> Lancamentos { get; private set; }

        public MLancamentoRepositorio()
        {
            Lancamentos = new List<Lancamento>();
        }

        public async Task Salva(Lancamento lancamento)
        {
            Lancamentos.Add(lancamento);
            await Task.CompletedTask;
        }
    }
}
