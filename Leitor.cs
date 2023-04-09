using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula2
{
    public class Leitor
    {
        public Leitor() { }
        public int Inteiro(string msg) {
            bool valid = false;
            int n = 0;
            do
            {
                Console.WriteLine(msg);
                valid = int.TryParse(Console.ReadLine(),out n);
            }
            while (valid == false);
            return n;
        }    
        public double PontoFlutuante(string msg) {
            bool valid = false;
            double n = 0.0;
            do
            {
                Console.WriteLine(msg);
                valid = double.TryParse(Console.ReadLine(), out n);
            }
            while (!valid);
            return n;
        }
        public string Caracteres(string msg)
        {
            Console.WriteLine(msg);
            string res = Console.ReadLine();
            return res;
        }
        
    }
}