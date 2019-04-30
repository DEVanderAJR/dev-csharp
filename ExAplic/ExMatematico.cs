using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            double X=0,y=0,z=0;

            while (X <= 500)
            {
                System.Console.Write("NUMERO:" + X);
                y=Math.Pow(X,2);
                System.Console.Write("Quadrado:" + y);
                z=Math.Pow(X,3);
                System.Console.Write("CUBO:" + z + "\n");
                X++;
  Console.ReadLine();
            }
          
        }
    }
}
