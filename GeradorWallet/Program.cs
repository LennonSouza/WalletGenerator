using System;
using System.Collections.Generic;
using System.IO;

namespace WalletGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Code Amount: ");
            int amount = Convert.ToInt32(Console.ReadLine());

            List<string> codes = new List<string>();
            for (int x = 0; x < amount; x++)
            {
                Random random = new Random();
                string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                char[] part1 = new char[5],
                    part2 = new char[5],
                    part3 = new char[5],
                    part4 = new char[5];

                int i = 0, z = 0, y = 0;
                for (int j = 0; j < part1.Length; j++, i++, z++, y++)
                {
                    part1[j] = letters[random.Next(letters.Length)];
                    part2[j] = letters[random.Next(letters.Length)];
                    part3[j] = letters[random.Next(letters.Length)];
                    part4[j] = letters[random.Next(letters.Length)];
                }

                string resultString = new String(part1),
                    resultString2 = new String(part2),
                    resultString3 = new String(part3),
                    resultString4 = new String(part4),
                    resultString5 = new String($"{resultString}-{resultString2}-{resultString3}-{resultString4}");

                codes.Add(resultString5);
                Console.WriteLine(resultString5);
            }
            File.WriteAllLines(@"Codes.txt", codes);
        }
    }
}
