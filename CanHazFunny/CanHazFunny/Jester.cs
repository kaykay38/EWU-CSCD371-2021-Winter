using System;

namespace CanHazFunny
{
    public class Jester
    {
        public IJokePrinter jokePrinter {get; private set;}
        public IJokeService jokeService {get; private set;}

        public Jester(IJokeService jokeService, IJokePrinter jokePrinter)
        {
            this.jokeService = jokeService ?? throw new ArgumentNullException();
            this.jokePrinter = jokePrinter ?? throw new ArgumentNullException();
        }

        public void TellJoke()
        {
            string joke;
            do
            {
                joke = jokeService.GetJoke();
            } while (joke.ToLower().Contains("chuck norris"));
            jokePrinter.PrintJoke(joke);
        }
    }
}
