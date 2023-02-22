using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        // Nome do arquivo de saída
        string fileName = "WalletCodes.txt";

        // Solicitar ao usuário quantos wallet codes serão gerados
        Console.WriteLine("Quantos wallet codes você deseja gerar?");
        int numCodes = int.Parse(Console.ReadLine());

        // Armazenar os wallet codes gerados
        HashSet<string> codes = new HashSet<string>();

        // Gerar os wallet codes
        while (codes.Count < numCodes)
        {
            // Gerar quatro segmentos com cinco caracteres cada
            string segment1 = GenerateSegment(random, 5);
            string segment2 = GenerateSegment(random, 5);
            string segment3 = GenerateSegment(random, 5);
            string segment4 = GenerateSegment(random, 5);

            // Combinar os segmentos em um único wallet code
            string walletCode = string.Format("{0}-{1}-{2}-{3}", segment1, segment2, segment3, segment4);

            // Adicionar o código gerado ao HashSet (não permitirá códigos duplicados)
            codes.Add(walletCode);
        }

        // Escrever os wallet codes em um arquivo de texto
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (string code in codes)
            {
                writer.WriteLine(code);
            }
        }

        Console.WriteLine("Os códigos foram salvos em {0}.", fileName);
    }

    static string GenerateSegment(Random random, int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
