using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Shared.Saida
{
    public interface ISaidaResultado
    {
        bool Successo { get; set; }
        string Mensagem { get; set; }
        object Data { get; set; }
    }
}
