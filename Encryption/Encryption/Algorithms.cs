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
