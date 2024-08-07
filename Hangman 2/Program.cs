namespace Hangman_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //constant variables at first:)
            const int MAX_NUMBER_OF_GUESSES = 20; // max number of guesses
            const string INSTRUCION = "Please give me a letter: ";
            const string UNDERLINE = "_ "; // I will use it to build up the current status of the word

            //here is our list of possible words:
            List<string> listOfWords = new List<string>();
            listOfWords.Add("APPLE");
            listOfWords.Add("PEAR");
            listOfWords.Add("ORANGE");
            listOfWords.Add("BANANA");
            listOfWords.Add("STRAWBERRY");
            listOfWords.Add("CHERRY");
            listOfWords.Add("PINEAPPLE");
            listOfWords.Add("RASPBERRY");
            listOfWords.Add("WATERMELON");
            listOfWords.Add("BLUEBERRY");
            listOfWords.Add("LEMON");
            listOfWords.Add("TOMATO");

            //here is my solution for the random word creation:
            Random random = new Random();
            int randomNumber = random.Next(listOfWords.Count);
            string word = listOfWords[randomNumber];

            string welcome = $"Welcome to my Hangman game Fruit edition! You have {MAX_NUMBER_OF_GUESSES} guesses! The system will now think of a random word: ";
            Console.WriteLine(welcome);

            //I build up the current state of the word "______" with a list so I can replace the elements easily and also practice working with lists:)
            List<string> currentStateOfWord = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                currentStateOfWord.Add(UNDERLINE);
            }
            
            //and this is how I visualize the current state of the word, I show it once before the first guess so that we can see the number of letters in the word that the computer randomly chose
            for (int x = 0; x < currentStateOfWord.Count; x++)
            {
                Console.Write(currentStateOfWord[x]);
            }

            //and then clear the screen for better visibility:
            Console.WriteLine("\r\nPlease press a button to Continue!");
            Console.ReadKey();
            Console.Clear();

            // keeping track of how many time the loop runs (it will be included in the loop later:) I just have to define the first definition outside of the loop)
            int keepingTrack = 0;

            do
            {
                Console.WriteLine(INSTRUCION);
                string letter = Console.ReadLine().ToUpper(); //guess made by the player

                if (word.Contains(letter))
                {
                    Console.WriteLine("Good guess!");

                    //and this is how I add the correctly guessed letters to the list, I go through the _ characters one by one, and if it matches the letter, I replace it with the letter
                    for (int x = 0; x < currentStateOfWord.Count; x++)
                    {
                        if (letter == word[x].ToString())
                        {
                            currentStateOfWord[x] = letter;
                        }
                    }

                    //and this is how I visualize the current state of the word so that we can see how many are still missing:
                    for (int x = 0; x < currentStateOfWord.Count; x++)
                    {
                        Console.Write(currentStateOfWord[x]);
                    }

                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                // keeping track of how many times the loop runs
                keepingTrack++;
                Console.WriteLine($"\r\nThis was your {keepingTrack}. guess");

                if (!currentStateOfWord.Contains(UNDERLINE))
                {
                    Console.WriteLine($"You Won the Game with {keepingTrack} Guesses!");
                    break;
                }

                if (keepingTrack == MAX_NUMBER_OF_GUESSES && currentStateOfWord.Contains(UNDERLINE))
                {
                    Console.WriteLine($"You lost! You reached {keepingTrack} Guesses!");
                    break;
                }

                //and then clear the screen before moving on to the next guess
                Console.WriteLine("\r\nPlease press a button to Continue!");
                Console.ReadKey();
                Console.Clear();

            } while (keepingTrack < MAX_NUMBER_OF_GUESSES); 
        }
    }
}
