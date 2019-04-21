using System;
using System.Collections.Generic;
using System.Text;

namespace Teste.Infra.Modelos
{
    public partial class TbContaCorrente
    {
        public TbContaCorrente()
        {
            TbLancamento = new HashSet<TbLancamento>();
        }

        public int Numero { get; set; }
        public decimal Saldo { get; set; }

        public ICollection<TbLancamento> TbLancamento { get; set; }
    }
}
