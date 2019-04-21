using System.Threading.Tasks;
using Teste.Domain.Entidades;

namespace Teste.Domain.Repositorios
{
    public interface IContaRepositorio
    {
        Task<ContaCorrente> Busca(int numeroConta);
        Task Atualiza(ContaCorrente contaCorrente);
    }
}
