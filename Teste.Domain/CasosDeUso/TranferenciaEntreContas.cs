using FluentValidator;
using System.Threading.Tasks;
using Teste.Domain.Entidades;
using Teste.Domain.Entrada;
using Teste.Domain.Repositorios;
using Teste.Shared.Saida;

namespace Teste.Domain.CasosDeUso
{
    public class TranferenciaEntreContas : Notifiable
    {
        private readonly IContaRepositorio _contaRepositoy;
        private readonly ILancamentoRepositorio _lancamentoRepositoy;

        public TranferenciaEntreContas(IContaRepositorio contaRepositoy, ILancamentoRepositorio lancamentoRepositoy)
        {
            _contaRepositoy = contaRepositoy;
            _lancamentoRepositoy = lancamentoRepositoy;
        }

        public async Task<ISaidaResultado> executa(TranferenciaEntreContasEntrada  entrada)
        {
            var contaOrigem = await _contaRepositoy.Busca(entrada.NumeroContaOrigem);
            var contaDestino = await _contaRepositoy.Busca(entrada.NumeroContaDestino);

            if (contaOrigem == null)
                AddNotification("Tranfêrencia", "Conta Origem não existe.");

            if (contaDestino == null)
                AddNotification("Tranfêrencia", "Conta Origem não existe.");

            if (entrada.Valor <= 0)
                AddNotification("Tranfêrencia", "Valor tem que ser maior que zero.");

            if (contaOrigem.Saldo < entrada.Valor)
                AddNotification("Tranfêrencia", "Saldo insuficiente para transferência.");

            if (Invalid)
                return await Task.FromResult(new SaidaResultado(false, "Por favor, corrija os campos abaixo", Notifications));

            contaOrigem.DebitaSaldo(entrada.Valor); 
            var lancamentoDebito = new Lancamento(contaOrigem.Numero, Enums.ETipoLancamento.Debito, entrada.Valor);
            await _lancamentoRepositoy.Salva(lancamentoDebito);
            await _contaRepositoy.Atualiza(contaOrigem);

            contaDestino.CreditaSaldo(entrada.Valor);
            var lancamentoCredito = new Lancamento(contaDestino.Numero, Enums.ETipoLancamento.Credito, entrada.Valor);
            await _lancamentoRepositoy.Salva(lancamentoCredito);
            await _contaRepositoy.Atualiza(contaDestino);

            return await Task.FromResult(new SaidaResultado(true, "Operação efetuada com sucesso.",Notifications));
        }
    }
}
