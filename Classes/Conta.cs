using System;

namespace ControleContas
{
   public class Conta
	{
		private TipoConta tipoConta { get; set; }
		private string cliente { get; set; }
		private double saldo { get; set; }
		private double credito { get; set; }

		public Conta(TipoConta tipoConta, string cliente, double saldo, double credito)
		{
			this.tipoConta = tipoConta;
			this.saldo = saldo;
			this.credito = credito;
			this.cliente = cliente;
		}

		public bool sacaValor(double valor)
		{
            if (this.saldo - valor < (this.credito * -1)){
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            this.saldo -= valor;
            Console.WriteLine("Operação realizada na conta de {0}", this.cliente);
            Console.WriteLine("Saldo atual: {0} , Crédito: {1}", this.saldo, this.credito);
            return true;
		}

		public void depositaValor(double valor)
		{
			this.saldo += valor;

            Console.WriteLine("O saldo atual da conta de {0} é {1}", this.cliente, this.saldo);
		}

		public void transfereValor(double valor, Conta contaDestino)
		{
			if (this.sacaValor(valor)){
                contaDestino.depositaValor(valor);
            }
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "TipoConta " + this.tipoConta + " | ";
            retorno += "Cliente "   + this.cliente   + " | ";
            retorno += "Saldo "     + this.saldo     + " | ";
            retorno += "Crédito "   + this.credito;
			return retorno;
		}
	}
}