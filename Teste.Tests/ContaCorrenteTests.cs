using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teste.Domain.Entidades;

namespace Teste.Tests
{
    [TestClass]
    public class ContaCorrenteTests
    {
        

        [TestMethod]
        [TestCategory("ContaCorrente - Nova ContaCorrente")]
        public void ContaCorrenteValida()
        {
            var contacorrente = new ContaCorrente(1,(decimal)100.50);
            Assert.IsTrue(contacorrente != null);
        }
    }
}
