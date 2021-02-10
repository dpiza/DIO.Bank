using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static List<Transacao> listTransacoes = new List<Transacao>();
        static void Main(string[] args)
        {
            
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.Clear();
                        MenuContas();
                        break;

                    case "2":
                        Console.Clear();
                        MenuTransacoes();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.Clear();
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine();
            
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Menu DIO Bank");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Menu contas");
            Console.WriteLine("2 - Transações");
            Console.WriteLine();
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
            
        }

        private static void MenuContas()
        {
            string opcaoMenuContas = ObterOpcaoMenuContas();

            while (opcaoMenuContas != "0")
            {
                switch (opcaoMenuContas)
                {
                    case "1":
                        Console.Clear();
                        InserirConta();
                        break;
                    
                    case "2":
                        Console.Clear();
                        ListarContas();
                        break;
                        
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.Clear();
                opcaoMenuContas = ObterOpcaoMenuContas();
            }
        }

        private static string ObterOpcaoMenuContas()
        {
            Console.WriteLine();
            Console.WriteLine("Menu DIO Bank - Contas");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Inserir nova conta");
            Console.WriteLine("2 - Listar contas");
            Console.WriteLine();
            Console.WriteLine("0 - Menu Anterior");
            Console.WriteLine();

            string opcaoMenuContas = Console.ReadLine();
            Console.WriteLine();
            return opcaoMenuContas;
        }

        private static void MenuTransacoes()
        {
            string opcaoMenuTransacoes = ObterOpcaoMenuTransacoes();

            while (opcaoMenuTransacoes != "0")
            {
                switch (opcaoMenuTransacoes)
                {
                    case "1":
                        Console.Clear();
                        Depositar();
                        break;
                    
                    case "2":
                        Console.Clear();
                        Sacar();
                        break;
                        
                    case "3":
                        Console.Clear();
                        Transferir();
                        break;

                    case "4":
                        Console.Clear();
                        ConsultarTransacoes();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.Clear();
                opcaoMenuTransacoes = ObterOpcaoMenuTransacoes();
            }
        }

        private static string ObterOpcaoMenuTransacoes()
        {
            Console.WriteLine();
            Console.WriteLine("Menu DIO Bank - Transações");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Depositar");
            Console.WriteLine("2 - Sacar");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Consultar Transações");
            Console.WriteLine();
            Console.WriteLine("0 - Menu Anterior");
            Console.WriteLine();

            string opcaoMenuTransacoes = Console.ReadLine();
            Console.WriteLine();
            return opcaoMenuTransacoes;
        }

        private static void GravaTransacao(int codTransacao, DateTime data, int conta, double valor)
        {
            Transacao addTransacao = new Transacao(codTransacao: (CodTransacao)codTransacao,
                                                    conta: conta,
                                                    valor: valor,
                                                    data: data);
            
            listTransacoes.Add(addTransacao);
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            
            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);

            Console.WriteLine("Conta {0} adicionada com sucesso!", entradaNome);
            Console.ReadLine();

        }

        private static void ConsultarTransacoes()
        {
            Console.WriteLine("Lista de Transações");

            if (listTransacoes.Count == 0)
            {
                Console.WriteLine("Nenhuma transação foi efetuada");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < listTransacoes.Count; i++)
            {
                Transacao transacao = listTransacoes[i];
                Console.WriteLine(transacao);
            }
            Console.ReadLine();
        }



        private static void ListarContas()
        {
            Console.WriteLine("Lista de Contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
                
            }
            Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);

            DateTime data = DateTime.Now;
            GravaTransacao(1, data, indiceConta, valorDeposito);

            Console.ReadLine();
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            if (!listContas[indiceConta].Sacar(valorSaque))
            {
                Console.ReadLine();
                return;
            }
            else
            {
            DateTime data = DateTime.Now;
            GravaTransacao(2, data, indiceConta, (valorSaque*-1));

            Console.ReadLine();
            }
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            
            if(!listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]))
            {
                Console.ReadLine();
                return;
            }
            else
            {
                DateTime data = DateTime.Now;
                GravaTransacao(3, data, indiceContaOrigem, (valorTransferencia*-1));
                GravaTransacao(3, data, indiceContaDestino, valorTransferencia);

                Console.ReadLine();
            }
        }
    }
}
