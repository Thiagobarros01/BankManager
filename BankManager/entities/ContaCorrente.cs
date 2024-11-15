using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.entities {
    class ContaCorrente : ContaBancaria{

        public decimal TaxaManutencao { get; private set; }

        public ContaCorrente(string numero, string titular, decimal saldoInicial, decimal taxaManutencao) 
            : base(numero, titular, saldoInicial) {
            TaxaManutencao = taxaManutencao;
        }

        public override void Sacar(decimal valor) {
            decimal valorComTaxa = valor + TaxaManutencao;
            if (valorComTaxa <= Saldo) {
                base.Sacar(valorComTaxa);
            }
            else {
                Console.WriteLine("Saldo insuficiente para cobrir o saque e a taxa de manutenção.");
            }
        }

        public override void ExibirDetalhes() {
            Console.WriteLine($"Conta Corrente - Número: {Numero}, Titular: {Titular}, Saldo: {Saldo:C}, Taxa de Manutenção: {TaxaManutencao:C}");
        }
    }

}

