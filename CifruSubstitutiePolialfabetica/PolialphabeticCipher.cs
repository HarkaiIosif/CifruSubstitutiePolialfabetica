using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifruSubstitutiePolialfabetica
{
    
        internal class PolialphabeticCipher
        {
            private Random rnd = new Random();
            private Dictionary<char, char> Dict1 = new Dictionary<char, char>();
            private Dictionary<char, char> Dict2 = new Dictionary<char, char>();
            private Dictionary<char, char> Dict3 = new Dictionary<char, char>();
            private List<Dictionary<char, char>> Dictionaries = new List<Dictionary<char, char>>();
            public PolialphabeticCipher()
            {
                GenerateDictionary(Dict1);
                GenerateDictionary(Dict2);
                GenerateDictionary(Dict3);
                Shuffle(Dict1);
                Shuffle(Dict2);
                Shuffle(Dict3);
                Dictionaries.Add(Dict1);
                Dictionaries.Add(Dict2);
                Dictionaries.Add(Dict3);
            }
            private void GenerateDictionary(Dictionary<char, char> dict)
            {
                dict.Add('a', 'a');
                dict.Add('b', 'b');
                dict.Add('c', 'c');
                dict.Add('d', 'd');
                dict.Add('e', 'e');
                dict.Add('f', 'f');
                dict.Add('g', 'g');
                dict.Add('h', 'h');
                dict.Add('i', 'i');
                dict.Add('j', 'j');
                dict.Add('k', 'k');
                dict.Add('l', 'l');
                dict.Add('m', 'm');
                dict.Add('n', 'n');
                dict.Add('o', 'o');
                dict.Add('p', 'p');
                dict.Add('q', 'q');
                dict.Add('r', 'r');
                dict.Add('s', 's');
                dict.Add('t', 't');
                dict.Add('u', 'u');
                dict.Add('v', 'v');
                dict.Add('w', 'w');
                dict.Add('x', 'x');
                dict.Add('y', 'y');
                dict.Add('z', 'z');
            }
            private void Shuffle(Dictionary<char, char> dict)
            {
                for (int i = dict.Count - 1; i > 0; i--)
                {
                    int j = rnd.Next(0, dict.Count);
                    (dict[dict.ElementAt(i).Key], dict[dict.ElementAt(j).Key]) = (dict[dict.ElementAt(j).Key], dict[dict.ElementAt(i).Key]);
                }
            }

            public string Encrypt(string inputmessage)
            {
                bool isUpper;
                char[] message = inputmessage.ToCharArray();
                for (int i = 0; i < message.Length; i++)
                {

                    char letter = message[i];
                    if (Char.IsLetter(letter))
                    {
                        if (Char.IsUpper(letter))
                        {
                            isUpper = true;
                            letter = Char.ToLower(letter);
                            letter = EncryptLetter(letter, i % 3);
                            letter = Char.ToUpper(letter);
                            isUpper = false;
                            message[i] = letter;
                        }
                        else
                        {
                            letter = EncryptLetter(letter, i % 3);
                            message[i] = letter;
                        }
                    }
                }
                string toReturn = new string(message);
                return toReturn;
            }
            private char EncryptLetter(char letter, int dictionarychoice)
            {
                char toReturn = Dictionaries[dictionarychoice][letter];
                return toReturn;
            }

            public string Decrypt(string inputmessage)
            {
                bool isUpper;
                char[] message = inputmessage.ToCharArray();
                for (int i = 0; i < message.Length; i++)
                {
                    char letter = message[i];
                    if (Char.IsLetter(letter))
                    {
                        if (Char.IsUpper(letter))
                        {
                            isUpper = true;
                            letter = Char.ToLower(letter);
                            letter = DecryptLetter(letter, i % 3);
                            letter = Char.ToUpper(letter);
                            isUpper = false;
                            message[i] = letter;
                        }
                        else
                        {
                            letter = DecryptLetter(letter, i % 3);
                            message[i] = letter;
                        }
                    }

                }
                string toReturn = new string(message);
                return toReturn;
            }
            private char DecryptLetter(char letter, int dictionarychoice)
            {
                char toReturn = '\0';
                for (int i = 0; i < Dictionaries[dictionarychoice].Count; i++)
                {
                    if (Dictionaries[dictionarychoice].ElementAt(i).Value == letter) toReturn = Dictionaries[dictionarychoice].ElementAt(i).Key;
                }
                return toReturn;
            }
        }
}

