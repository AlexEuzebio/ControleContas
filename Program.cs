using System;
using System.Collections.Generic;

namespace ControleContas
{
	class Program 
	{
		static List<Conta> cadastroContas = new List<Conta>();
		static void Main(string[] args)
		{
			string opcaoMenu = obtemOpcaoMenu();

			while (opcaoMenu.ToUpper() != "X")
			{
				switch (opcaoMenu)
				{
					case "1":
						incluiConta();						
						break;
					case "2":
						transfereValor();
						break;
					case "3":
						sacaValor();
						break;
					case "4":
						depositaValor();
                        break;
					case "5":
						listagemContas();
						break;
                    case "L":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoMenu = obtemOpcaoMenu();
			}
			
			Console.WriteLine("Sistema encerrado.");
			Console.ReadLine();
		}
		private static void incluiConta()
		{
			Console.WriteLine("---> Nova conta <---");

			Console.Write("1 = Conta Fisica ; 2 = Juridica: ");
			int tipoConta = int.Parse(Console.ReadLine());

			Console.Write("Nome do cliente: ");
			string cliente = Console.ReadLine();

			Console.Write("Saldo inicial: ");
			double saldo = double.Parse(Console.ReadLine());

			Console.Write("Crédito do cliente: ");
			double credito = double.Parse(Console.ReadLine());

			Conta novaConta = new Conta(tipoConta: (TipoConta)tipoConta, cliente, saldo, credito );

			cadastroContas.Add(novaConta);
		}

		private static void transfereValor()
		{

        	int indiceOrigem = obtemCodigoConta("Conta origem:");
            int indiceDestino = obtemCodigoConta("Conta destino:");
			double valorTransferencia = obtemValor("Valor para transferência: ");

            cadastroContas[indiceOrigem].transfereValor(valorTransferencia, cadastroContas[indiceDestino]);
		}

        private static void sacaValor()
		{
			int indice = obtemCodigoConta("");
			double valorSaque = obtemValor("Valor para saque: ");

            cadastroContas[indice].sacaValor(valorSaque);
		}

		private static void depositaValor()
		{
			
			int indice = obtemCodigoConta("");
			double valorDeposito = obtemValor("Valor para depósito: ");

            cadastroContas[indice].depositaValor(valorDeposito);
		}
		private static void listagemContas()
		{
			Console.WriteLine("---> Listagem de contas <---");
			if (cadastroContas.Count == 0)
			{
				Console.WriteLine("Não há contas cadastradas");
				return;
			}
			for (int n = 0; n < cadastroContas.Count; n++)
			{
				Console.Write("#{0} - ", n);
				Console.WriteLine(cadastroContas[n]);
			}
		}

        private static double obtemValor(string mensagem)
        {
			Console.Write(mensagem);
			return double.Parse(Console.ReadLine());

        }

        private static int obtemCodigoConta(string mensagem)
        {
			if (mensagem != "") {
				Console.WriteLine(mensagem);
			}
			Console.Write("Código da conta: ");
			return int.Parse(Console.ReadLine());
        }


		private static string obtemOpcaoMenu()
		{
			Console.WriteLine();
			Console.WriteLine("Controle de Contas");
			Console.WriteLine("Opções:");

			Console.WriteLine("1 - Incluir conta");
			Console.WriteLine("2 - Transferir valor entre contas");
			Console.WriteLine("3 - Efetuar saque");
			Console.WriteLine("4 - Efetuar depósito");
			Console.WriteLine("5 - Listar contas");
            Console.WriteLine("L - Limpar a tela");
			Console.WriteLine("X - Encerrar o sistema");
			Console.WriteLine();

			string opcaoMenu = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoMenu;
		}
	}
}
