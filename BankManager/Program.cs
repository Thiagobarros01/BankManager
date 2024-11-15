using BankManager.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager {
    internal class Program {

        static List<ContaBancaria> contas = new List<ContaBancaria>();

        static void Main(string[] args) {
            

            while (true) {
                Console.WriteLine("\nGerenciador de Contas Bancárias");
                Console.WriteLine("1. Criar Conta Corrente");
                Console.WriteLine("2. Criar Conta Poupança");
                Console.WriteLine("3. Depositar");
                Console.WriteLine("4. Sacar");
                Console.WriteLine("5. Exibir Detalhes da Conta");
                Console.WriteLine("6. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                switch (opcao) {
                    case "1":
                        CriarContaCorrente();
                        break;
                    case "2":
                        CriarContaPoupanca();
                        break;
                    case "3":
                        Depositar();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        ExibirDetalhes();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void CriarContaCorrente() {
            Console.Write("Número da conta: ");
            string numero = Console.ReadLine();
            Console.Write("Titular: ");
            string titular = Console.ReadLine();
            Console.Write("Saldo inicial: ");
            decimal saldoInicial = decimal.Parse(Console.ReadLine());
            Console.Write("Taxa de manutenção: ");
            decimal taxa = decimal.Parse(Console.ReadLine());

            contas.Add(new ContaCorrente(numero, titular, saldoInicial, taxa));
            Console.WriteLine("Conta Corrente criada com sucesso!");
        }

        static void CriarContaPoupanca() {
            Console.Write("Número da conta: ");
            string numero = Console.ReadLine();
            Console.Write("Titular: ");
            string titular = Console.ReadLine();
            Console.Write("Saldo inicial: ");
            decimal saldoInicial = decimal.Parse(Console.ReadLine());
            Console.Write("Rendimento (%): ");
            decimal rendimento = decimal.Parse(Console.ReadLine());

            contas.Add(new ContaPoupanca(numero, titular, saldoInicial, rendimento));
            Console.WriteLine("Conta Poupança criada com sucesso!");
        }

        static void Depositar() {
            ContaBancaria conta = SelecionarConta();
            if (conta != null) {
                Console.Write("Valor para depósito: ");
                decimal valor = decimal.Parse(Console.ReadLine());
                conta.Depositar(valor);
            }
        }

        static void Sacar() {
            ContaBancaria conta = SelecionarConta();
            if (conta != null) {
                Console.Write("Valor para saque: ");
                decimal valor = decimal.Parse(Console.ReadLine());
                conta.Sacar(valor);
            }
        }

        static void ExibirDetalhes() {
            ContaBancaria conta = SelecionarConta();
            if (conta != null) {
                conta.ExibirDetalhes();
            }
        }

        static ContaBancaria SelecionarConta() {
            if (contas.Count == 0) {
                Console.WriteLine("Nenhuma conta disponível.");
                return null;
            }

            Console.WriteLine("Selecione o número da conta:");
            for (int i = 0; i < contas.Count; i++) {
                Console.WriteLine($"{i + 1}. {contas[i].Numero} - {contas[i].Titular}");
            }

            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= contas.Count) {
                return contas[indice - 1];
            }
            else {
                Console.WriteLine("Número inválido.");
                return null;
            }
        }
    }
}


