using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Repositorios;
using Teste.Infra.Contexto;

namespace Teste.Infra.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly DbTesteContext _context;

        public ClienteRepositorio(DbTesteContext context)
        {
            _context = context;
        }

        public async Task<bool> ValidaCliente(string cpf, string senha)
        {
            if (_context.TbCliente.Where(x => x.Cpf.ToUpper().Trim() == cpf.ToUpper().Trim()
                                         && x.Senha.ToUpper().Trim() == senha.ToUpper().Trim()).Count() > 0)
                return await Task.FromResult(true);

            return await Task.FromResult(false);
        }
    }
}
