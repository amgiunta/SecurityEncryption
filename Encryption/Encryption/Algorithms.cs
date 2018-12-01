using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Algorithms
{
    public class Algorithm {
        public string name;

        public Algorithm(string name) {
            this.name = name;
        }

        public virtual string Encrypt(string plainText) { return plainText; }
        public virtual string Decrypt(string cipherText) { return cipherText; }
    }

    public class Binary : Algorithm {
        private struct bin {
            int value;

            public override string ToString()
            {
                return value.ToString();
            }

            public static implicit operator bin(int other) {
                bin b;
                string converted = Convert.ToString(other, 2);
                b.value = Int32.Parse(converted);
                return b;
            }

            public static implicit operator int(bin other) {
                int converted = Convert.ToInt32(other.value.ToString(), 2);
                return converted;
            }

            public static explicit operator bin(string other) {
                bin b;
                b.value = Int32.Parse(other);
                return b;
            }
        }

        public Binary(string name = "binary") : base(name) { }

        public override string Encrypt(string plainText)
        {
            string ciphertext = "";

            foreach (char character in plainText) {
                bin binary = character;
                ciphertext += binary.ToString() + " ";
            }

            return ciphertext;
        }

        public override string Decrypt(string cipherText)
        {
            string[] ciphermedley = cipherText.Split(' ');
            string plainText = "";

            foreach (bin b in ciphermedley) {
                char c = (char) b;
                plainText += c;
            }

            return plainText;
        }
    }

    public class Cesar : Algorithm {
        
        private int shiftAmount;

        public Cesar(string name = "cesar") : base(name) {
            shiftAmount = 3;
        }

        public Cesar(int shiftAmount, string name = "cesar") : base(name) {
            this.shiftAmount = shiftAmount;
        }

        public override string Encrypt(string plainText)
        {
            List<char> chars = new List<char>(plainText.ToCharArray());
            string cipherText = "";
            foreach (char character in chars) {
                char newChar = character;
                newChar = (char) (newChar + shiftAmount);
                cipherText = cipherText + newChar;
            }

            return cipherText;
        }

        public override string Decrypt(string cipherText)
        {
            List<char> chars = new List<char>(cipherText.ToCharArray());
            string plainText = "";
            foreach (char character in chars) {
                char newChar = character;
                newChar = (char)(newChar - shiftAmount);
                plainText = plainText + newChar;
            }

            return plainText;
        }
    }
}
