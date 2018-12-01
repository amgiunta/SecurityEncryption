using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encryption.Algorithms;

namespace Encryption
{
    class Program
    {
        public static List<Algorithm> loadedAlgorithms = new List<Algorithm>();

        public static string GetInput(string prompt, bool clearScreen = false) {
            if (clearScreen) { Console.Clear(); }
            Console.WriteLine(prompt);

            string input = Console.ReadLine();
            return input;
        }

        private static void ListAlgorithms() {
            Console.Clear();

            int count = 0;
            foreach (Algorithm alg in loadedAlgorithms) {
                Console.WriteLine(count + " ----- " + alg.name);
            }
        }

        private static Algorithm GetAlgorithm() {
            ListAlgorithms();
            string name = GetInput("Please enter the type of algorithm you would like to use by name.");

            Algorithm algorithm = null;

            foreach (Algorithm alg in loadedAlgorithms) {
                if (alg.name == name.ToLower()) { algorithm = alg; }
            }

            if (algorithm == null) { GetInput("The algorithm you entered does not exist. Please try again...[press enter]", true); return GetAlgorithm(); }

            return algorithm;
        }

        private static string Encrypt() { 
            Algorithm alg = GetAlgorithm();
            if (alg == null) { GetInput("That is not a valid algorithm. Please try again. [press ENTER]", true); Encrypt(); }

            string input = GetInput("Please type the text that you would like to encrypt.");

            return alg.Encrypt(input);
        }

        private static string Decrypt() {
            Algorithm alg = GetAlgorithm();
            if (alg == null) { GetInput("That is not a valid algorithm. Please try again. [press ENTER]", true); Encrypt(); }

            string input = GetInput("Please enter the text you would like to decrypt.");

            return alg.Decrypt(input);
        }

        private static void EncryptDecrypt() {
            Console.Clear();
            string input = GetInput("Would you like to encrypt, or decrypt a message? (encrypt or decrypt)", true);
            if (input.ToLower() == "encrypt")
            {
                string text = Encrypt();
                Console.WriteLine("Your new encrypted message is:");
                Console.WriteLine(text);
            }
            else if (input.ToLower() == "decrypt")
            {
                string text = Decrypt();
                Console.WriteLine("Your decrypted message is:");
                Console.WriteLine(text);
            }
            else { GetInput("That is not a valid operation. Press enter to try again", true); EncryptDecrypt(); }
        }

        private static void Initialize() {
            Console.Clear();
            loadedAlgorithms.Add(new Cesar());
            loadedAlgorithms.Add(new Cesar(6, "double cesar"));
            loadedAlgorithms.Add(new Binary());
        }

        private static bool ReRun() {
            string input = GetInput("Would you like to run the program again? (y or n)");

            if (input.ToLower() == "y")
            {
                return true;
            }
            else if (input.ToLower() == "n")
            {
                return false;
            }
            else { Console.WriteLine("That was not a recognized command..."); return ReRun(); }
        }

        static void Main(string[] args)
        {
            Initialize();
            do
            {
                EncryptDecrypt();
            } while (ReRun());
        }
    }
}
