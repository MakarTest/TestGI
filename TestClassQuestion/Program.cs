using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGI;

namespace TestClassQuestion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question q = new Question("Какйо то вопрос", -1);
            Console.WriteLine(q.ToString());
        }
    }
}
