using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Aula2
{
    internal class Program
    {
        public Program()
        {

            Menu menu = new Menu();
            menu.MenuOpcoes();
               
        }
        static void Main(string[] args)
        {
            
            Program tst= new Program();
            Console.ReadLine();
            
        }
    }
}
