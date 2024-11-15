using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.entities {
    abstract class ContaBancaria {

        public string Numero { get; private set; }
        public string Titular { get; private set; }
        public decimal Saldo { get; protected set; }

        public ContaBancaria(string numero, string titular, decimal saldoInicial) {
            Numero = numero;
            Titular = titular;
            Saldo = saldoInicial;
        }

        public virtual void Depositar(decimal valor) {
            if (valor > 0) {
                Saldo += valor;
                Console.WriteLine($"Depósito de {valor:C} realizado com sucesso!");
            }
            else {
                Console.WriteLine("O valor do depósito deve ser positivo.");
            }
        }

        public virtual void Sacar(decimal valor) {
            if (valor > 0 && Saldo >= valor) {
                Saldo -= valor;
                Console.WriteLine($"Saque de {valor:C} realizado com sucesso!");
            }
            else {
                Console.WriteLine("Saque inválido. Verifique o saldo ou o valor solicitado.");
            }
        }

        public abstract void ExibirDetalhes();

    }
}
