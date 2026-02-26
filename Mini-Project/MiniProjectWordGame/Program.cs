namespace MiniProjectWordGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            words.Add("Banana");
            words.Add("Keyboard");
            words.Add("Apple");
            words.Add("Notebook");
            words.Add("Train");

            Random rnd = new Random();
            int index = rnd.Next(words.Count);
            string word = words[index].ToUpper();

            char[] dash = new char[word.Length];
            for (int i = 0; i < dash.Length; i++)
            {
                dash[i] = '_';
            }
            int lives = 6;

            List<char> guessed = new List<char>();

            Console.WriteLine("Welcome To C# Hangman!");

            while (lives > 0)
            {
                Console.Write("Word: ");
                for (int i = 0; i < dash.Length; i++)
                    Console.Write(dash[i] + " ");
                Console.WriteLine();

                Console.WriteLine("Lives left: " + lives);

                Console.Write("Guessed: ");
                for (int i = 0; i < guessed.Count; i++)
                    Console.Write(guessed[i] + " ");
                Console.WriteLine();

                Console.Write("Guess a letter: ");
                string input = Console.ReadLine().ToUpper();
                if (input.Length == 0) continue;

                char g = input[0];

                if (guessed.Contains(g))
                {
                    Console.WriteLine("Already guessed.\n");
                    continue;
                }

                guessed.Add(g);

                bool found = false;

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == g)
                    {
                        dash[i] = g;
                        found = true;
                    }
                }

                if (found)
                    Console.WriteLine("Good catch!\n");
                else
                {
                    lives--;
                    Console.WriteLine("Nope! That's not in the word.\n");
                }

                bool win = true;
                for (int i = 0; i < dash.Length; i++)
                    if (dash[i] == '_') win = false;

                if (win)
                {
                    Console.WriteLine("You win!");
                    break;
                }
            }

            if (lives == 0)
                Console.WriteLine("Game over! Word was: " + word);
        }
    }
}
