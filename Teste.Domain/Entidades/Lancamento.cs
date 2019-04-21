using System;
using System.Collections.Generic;
using System.Text;
using Teste.Domain.Enums;

namespace Teste.Domain.Entidades
{
    public class Lancamento
    {
        public Lancamento(int numeroConta, ETipoLancamento tipo, decimal valor)
        {
            NumeroConta = numeroConta;
            Tipo = tipo;
            Data = DateTime.Now;
            this.valor = valor;
        }

        public int NumeroConta { get; private set; }
        public ETipoLancamento Tipo { get; private set; }
        public DateTime Data { get; private set; }
        public decimal valor { get; private set; }
    }
}
