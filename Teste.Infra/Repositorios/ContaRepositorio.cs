using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Entidades;
using Teste.Domain.Repositorios;
using Teste.Infra.Contexto;
using Teste.Infra.Modelos;

namespace Teste.Infra.Repositorios
{
    public class ContaRepositorio : IContaRepositorio
    {
        private readonly DbTesteContext _context;

        public ContaRepositorio(DbTesteContext context)
        {
            _context = context;
        }


        public async Task<ContaCorrente> Busca(int numeroConta)
        {
            var conta = _context.TbContaCorrente.Where(x => x.Numero == numeroConta).FirstOrDefault();

            if(conta == null)
                return null;

            return await Task.FromResult(new ContaCorrente(conta.Numero, conta.Saldo));
        }

        public async Task Atualiza(ContaCorrente contaCorrente)
        {
            var conta = _context.TbContaCorrente.Where(x => x.Numero == contaCorrente.Numero).FirstOrDefault();
            conta.Saldo = contaCorrente.Saldo;
            _context.Entry<TbContaCorrente>(conta).State = EntityState.Modified;
            _context.SaveChanges();
            await Task.CompletedTask;
        }
    }
}
