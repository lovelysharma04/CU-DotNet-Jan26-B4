using GreetingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name= Console.ReadLine();
            Console.WriteLine(GreetingHelper.GetGreeting(name));
        }
    }
}
