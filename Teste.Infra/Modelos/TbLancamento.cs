using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Infra.Modelos
{
    public partial class TbLancamento
    {
        public TbLancamento(int numeroConta, int tipo, decimal valor)
        {
            NumeroConta = numeroConta;
            Tipo = tipo;
            Data = DateTime.Now;
            Valor = valor;
        }

        public int Id { get; set; }
        public int NumeroConta { get; set; }
        public int Tipo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        public TbContaCorrente NumeroContaNavigation { get; set; }
    }
}
