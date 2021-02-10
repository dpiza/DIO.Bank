using System;

namespace DIO.Bank
{
    public class Transacao
    {
        private CodTransacao CodTransacao { get; set; }

        private int Conta { get; set; }

        private double Valor { get; set; }

        private DateTime Data { get; set; }

        public Transacao (CodTransacao codTransacao, int conta, double valor, DateTime data)
        {
            this.CodTransacao = codTransacao;
            this.Conta = conta;
            this.Valor = valor;
            this.Data = data;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Data " + this.Data + " | ";
            retorno += "Transação " + this.CodTransacao + " | ";
            retorno += "Conta " + this.Conta + " | ";
            retorno += "Valor " + this.Valor;
            return retorno;
        }
    }
}