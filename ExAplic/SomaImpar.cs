using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soma_inteiro_impar
{
    class Program
    {
        static void Main(string[] args)
        {int x=0, soma=0;

        for (x = 1; x <= 99; x++)
        {
            if (x % 2 != 0)
            {
                soma = soma + x;
                    Console.WriteLine("Impares:"+ x+ "\n");
            }
        }
        Console.WriteLine("Soma Total:" + soma);
        Console.ReadLine();
        }
    }
}
