using System.Threading.Tasks;

namespace Teste.Domain.Repositorios
{
    public interface IClienteRepositorio
    {
        Task<bool> ValidaCliente(string cpf, string senha);
    }
}
