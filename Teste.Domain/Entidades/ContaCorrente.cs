namespace Teste.Domain.Entidades
{
    public class ContaCorrente  
    {
        public int Numero { get; private set; }
        public decimal Saldo { get; private set; }

        public ContaCorrente(int numero, decimal saldo)
        {
            Numero = numero;
            Saldo = saldo;
        }

        public void DebitaSaldo(decimal valor)
        {
            Saldo -= valor;
        }

        public void CreditaSaldo(decimal valor)
        {
            Saldo += valor;
        }
    }
}