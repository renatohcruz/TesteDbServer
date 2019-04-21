using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Shared.Saida
{
    public class SaidaResultado : ISaidaResultado
    {
        public SaidaResultado(bool successo, string mensagem, object data)
        {
            Successo = successo;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Successo { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }
    }
}
