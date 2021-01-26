using System;

namespace CanHazFunny
{
    public class JokePrinter : IJokePrinter
    {
        public void PrintJoke(string joke) 
        {
            Console.WriteLine("Joke: "+joke);
        }
    }
}
