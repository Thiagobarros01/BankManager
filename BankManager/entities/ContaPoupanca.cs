using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.entities {
    class ContaPoupanca : ContaBancaria {

        public decimal Rendimento { get; private set; }

        public ContaPoupanca(string numero, string titular, decimal saldoInicial, decimal rendimento)
            : base(numero, titular, saldoInicial) {
            Rendimento = rendimento;
        }

        public void AplicarRendimento() {
            Saldo += Saldo * Rendimento / 100;
            Console.WriteLine($"Rendimento de {Rendimento}% aplicado. Novo saldo: {Saldo:C}");
        }

        public override void ExibirDetalhes() {
            Console.WriteLine($"Conta Poupança - Número: {Numero}, Titular: {Titular}, Saldo: {Saldo:C}, Rendimento: {Rendimento}%");
        }
    }


}

