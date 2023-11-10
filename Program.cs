using System;
using System.Text;

class Program
{
    static void ReverseArrayInPlace(char[] array)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left < right)
        {
            char temp = array[left];
            array[left] = array[right];
            array[right] = temp;
            left++;
            right--;
        }
    }

    static string correctText(string text, string[] unacceptableWords)
    {
        string[] words = text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i].ToLower();

            foreach (string unacceptableWord in unacceptableWords)
            {
                if (word.Contains(unacceptableWord))
                {
                    words[i] = new string('*', unacceptableWord.Length);
                    break;
                }
            }
        }

        return string.Join(" ", words);
    }
    static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!#$%^&*()_+/-";
        var random = new Random();
        char[] result = new char[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = chars[random.Next(chars.Length)];
        }

        return new string(result);
    }
    static string SortRandomString(string input)
    {
        char[] sortedChars = input.ToCharArray();
        Array.Sort(sortedChars);
        return new string(sortedChars);
    }
    static string CompressDNA(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        char[] nucleotides = input.ToCharArray();
        string compressed = string.Empty;

        foreach (char nucleotide in nucleotides)
        {
            switch (nucleotide)
            {
                case 'A':
                    compressed += "00";
                    break;
                case 'C':
                    compressed += "01";
                    break;
                case 'G':
                    compressed += "10";
                    break;
                case 'T':
                    compressed += "11";
                    break;
                default:
                    throw new ArgumentException("Invalid DNA nucleotide: " + nucleotide);
            }
        }
        return compressed;
    }

    static string DecompressDNA(string compressed)
        {
            if (string.IsNullOrEmpty(compressed) || compressed.Length % 2 != 0)
                throw new ArgumentException("Invalid compressed DNA string.");

            char[] bits = compressed.ToCharArray();
            string decompressed = string.Empty;

            for (int i = 0; i < bits.Length; i += 2)
            {
                string pair = new string(new char[] { bits[i], bits[i + 1] });

                switch (pair)
                {
                    case "00":
                        decompressed += "A";
                        break;
                    case "01":
                        decompressed += "C";
                        break;
                    case "10":
                        decompressed += "G";
                        break;
                    case "11":
                        decompressed += "T";
                        break;
                    default:
                        throw new ArgumentException("Invalid compressed DNA pair: " + pair);
                }
            }

            return decompressed;
        }
        static string Encrypt(string input, int stepShift)
        {
            string result = "";
            foreach (char symbol in input)
            {
                result += (char)(symbol + stepShift);
            }
            return result;
        }
        static string Decrypt(string inputCipher, int stepShift)
        {
            return Encrypt(inputCipher, -stepShift);
        }

        static void Main()
        {
            //Task1: Реверс строки/масиву. Без додаткового масиву. Складність О(n).
            Console.Write("Task1: Input a string: ");
            string inputStr = Console.ReadLine();
            char[] characters = inputStr.ToCharArray();
            ReverseArrayInPlace(characters);
            string reversedString = new string(characters);
            Console.WriteLine("Reversing string: " + reversedString);

            //Task2: Фільтрування неприпустимих слів у строці
            string text = "Do not resolve host names when checking client connections. Use only FUCKING IP addresses!";
            string[] unacceptableWords = { "fuck", "fucking", "ass" };
            string correctedText = correctText(text, unacceptableWords);
            Console.WriteLine($"Task2: {correctedText}");

            //Task3: Генератор випадкових символів
            Console.Write("Task3: Input the desired number of characters: ");
            int length = int.Parse(Console.ReadLine());
            string randomString = GenerateRandomString(length);
            string sortedRandomString = SortRandomString(randomString);
            Console.WriteLine("Random string: " + sortedRandomString);

            //Task4: "Дірка" (пропущене число) у масиві.
            int[] array = { 1, 3, 0, 2, 5, 7, 6, 8, 9 };
            int n = array.Length + 1;
            int expectedSum = (n * (n - 1)) / 2;
            int actualSum = 0;

            foreach (int number in array)
            {
                actualSum += number;
            }

            int missingNumber = expectedSum - actualSum;
            Console.WriteLine($"Task4: Missing number in the array: {missingNumber}");

            //Task5: Найпростіше стиснення ланцюжка ДНК. 
            string originalDNA = "ACGTACGTACGT";
            string compressedDNA = CompressDNA(originalDNA);
            Console.WriteLine("Task5: Original DNA: " + originalDNA);
            Console.WriteLine("Compressed DNA: " + compressedDNA);
            string decompressedDNA = DecompressDNA(compressedDNA);
            Console.WriteLine("Decompressed DNA: " + decompressedDNA);

            //Task6: Симетричне шифрування.
            Console.WriteLine("Task6: Input a string to encrypt: ");
            string input = Console.ReadLine();
            Console.WriteLine("Input the step shift");
            int stepShift = int.Parse(Console.ReadLine());
            string encrypted = Encrypt(input, stepShift);
            Console.WriteLine($"Encrypted string: {encrypted}");
            Console.WriteLine("Input a string to decrypt: ");
            string inputCipher = Console.ReadLine();
            string decrypted = Decrypt(inputCipher, stepShift);
            Console.WriteLine($"Decrypted string: {decrypted}");
        }
    }


