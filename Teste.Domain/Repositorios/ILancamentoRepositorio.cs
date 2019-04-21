using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.Entidades;

namespace Teste.Domain.Repositorios
{
    public interface ILancamentoRepositorio
    {
        Task Salva(Lancamento lancamento);
    }
}
