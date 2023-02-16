using System;
using System.IO;
using System.Reflection;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o texto para ser criptografado.");
            string texto_original = Console.ReadLine();
            string nome_arquivo = "input.txt";
            File.WriteAllText(nome_arquivo, texto_original);

            Console.WriteLine("Digite 1 para criptografar ou 2 para decriptografar.");
            string opcao_string = Console.ReadLine();
            while (opcao_string != "1" && opcao_string != "2")
            {
                Console.WriteLine("\r\nResposta inválida!");
                Console.WriteLine("Digite 1 para criptografar ou 2 para decriptografar.");
                opcao_string = Console.ReadLine();
            }
            int opcao = int.Parse(opcao_string);

            Console.WriteLine("Digite por quantos caracteres será feita a criptografia/decriptografia.");
            string troca_string = Console.ReadLine();
            var numerico = int.TryParse(troca_string, out int troca);
            while (!numerico || troca < 1)
            {
                Console.WriteLine("\r\nResposta inválida!");
                Console.WriteLine("Digite por quantos caracteres será feita a criptografia/decriptografia.");
                troca_string = Console.ReadLine();
                numerico = int.TryParse(troca_string, out troca);
            }
            string titulo = opcao == 1 ? "criptografado" : "decriptografado";
            string cifra_texto = Caesar(File.ReadAllText(nome_arquivo), troca, opcao == 1 ? 1 : 2);
            File.WriteAllText("output.txt", cifra_texto);
            Console.WriteLine("Texto " + titulo + ".");
        }

        static string Caesar(string texto, int troca, int modo)
        {
            string alfabeto = "abcdefghijklmnopqrstuvwyzàáãâéêóôõíúçABCDEFGHIJKLMNOPQRSTUVWYZÀÁÃÂÉÊÓÕÍÚÇ";
            string novo_texto = "";
            foreach (char c in texto)
            {
                int index = alfabeto.IndexOf(c);
                if (index == -1)
                    novo_texto += c;
                else
                {
                    int novo_index;
                    if (modo == 1)
                        novo_index = index + troca;
                    else
                        novo_index = index - troca;

                    novo_index = novo_index % alfabeto.Length;
                    novo_texto += alfabeto.Substring(novo_index, 1);
                }
            }
            return novo_texto;
        }
    }
}