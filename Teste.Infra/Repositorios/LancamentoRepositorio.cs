using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Entidades;
using Teste.Domain.Repositorios;
using Teste.Infra.Contexto;
using Teste.Infra.Modelos;

namespace Teste.Infra.Repositorios
{
    public class LancamentoRepositorio : ILancamentoRepositorio
    {
        private readonly DbTesteContext _context;

        public LancamentoRepositorio(DbTesteContext context)
        {
            _context = context;
        }

        public async Task Salva(Lancamento lancamento)
        {
            var tbLancamento = new TbLancamento(lancamento.NumeroConta, 
                                                (int)lancamento.Tipo, 
                                                lancamento.valor);

            _context.TbLancamento.Add(tbLancamento);
            _context.SaveChanges();
            await Task.CompletedTask;
        }
    }
}
