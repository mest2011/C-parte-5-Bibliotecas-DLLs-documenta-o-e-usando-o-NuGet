using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Modelos;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime data1 = new DateTime(2020, 5, 15);
            DateTime data2 = new DateTime(2020, 8, 12);

            TimeSpan diferenca = data2 - data1;

            Console.WriteLine("Tempo ate fim do pagamento " + TimeSpanHumanizeExtensions.Humanize(diferenca));

            Console.ReadLine();
        }


        static string ConverteDataFimPagamento(TimeSpan diferenca)
        {
            if (diferenca.Days > 30)
            {
                return diferenca.Days / 30 + " mes(es)";
            }else if(diferenca.Days > 7)
            {
                return diferenca.Days / 7 + " semana(s)";
            }

            return diferenca.Days + " dia(s)";
        }

    }
}
