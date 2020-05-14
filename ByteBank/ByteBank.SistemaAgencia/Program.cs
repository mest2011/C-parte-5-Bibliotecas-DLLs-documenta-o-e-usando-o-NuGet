using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;


namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente( 132, 156165);
            Console.WriteLine(conta.Numero);

            ContaCorrente conta2 = new ContaCorrente(45, 4654);

            conta2.Saldo = 10;

            conta2.Sacar(5);

            Console.WriteLine(conta2.Saldo);

            Console.ReadLine();
        }


    }
}
