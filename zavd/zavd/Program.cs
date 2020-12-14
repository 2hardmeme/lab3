using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zavd
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMatrix yehor = new MyMatrix("1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 1 2 3 4 5 6 7 8");
            yehor.TransponeMe(yehor);
            Console.WriteLine(yehor);
            Console.Read();
        }
    }
}
