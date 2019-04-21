using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teste.Domain.CasosDeUso;
using Teste.Domain.Entrada;
using Teste.Tests.MockRepsoitorio;

namespace Teste.Tests
{
    [TestClass]
    public class TranferenciaEntreContasTests
    {
        [TestMethod]
        public async Task TranferenciaEntreContasComSucesso()
        {
            var mockContaRepositorio = new MContaRepositorio();
            var mockLancamentoRepositorio = new MLancamentoRepositorio();

            var tranferecia = new TranferenciaEntreContas(mockContaRepositorio, mockLancamentoRepositorio);
            var entrada = new TranferenciaEntreContasEntrada() { NumeroContaDestino = 1, NumeroContaOrigem = 2, Valor = 10 };

            var resulatdo = await tranferecia.executa(entrada);

            
            Assert.IsTrue(resulatdo.Successo == true);
            Assert.IsTrue(mockLancamentoRepositorio.Lancamentos.Count == 2);
            await Task.CompletedTask;
        }

        [TestMethod]
        public async Task TranferenciaEntreContasComValorMaiorQueSaldo()
        {
            var mockContaRepositorio = new MContaRepositorio();
            var mockLancamentoRepositorio = new MLancamentoRepositorio();

            var tranferecia = new TranferenciaEntreContas(mockContaRepositorio, mockLancamentoRepositorio);
            var entrada = new TranferenciaEntreContasEntrada() { NumeroContaDestino = 1, NumeroContaOrigem = 2, Valor = 1000 };

            var resulatdo = await tranferecia.executa(entrada);
            Assert.IsTrue(resulatdo.Successo == false);
            await Task.CompletedTask;
        }
    }
}
