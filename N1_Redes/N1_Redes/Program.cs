using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace N1_Redes
{
    class Program
    {
        /*
         TRABALHO DE N1 DE TÓPICOS AVANÇADOS EM REDES
         ALUNOS:
         ISABELLE OKUMA DE OLIVEIRA     RA: 082180004
         LAURA GABRIELA BENTO           RA: 082180029
         MARIA GABRIELA MOTA AKAMINE    RA: 082180010
         RAPHAEL KONICHI DE MORAES      RA: 082180028
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Digite 1 para criptografar ou 2 para decriptografar.");
            string opcao_string = Console.ReadLine();
            while (opcao_string != "1" && opcao_string != "2")
            {
                Console.WriteLine("\r\nResposta inválida!");
                Console.WriteLine("Digite 1 para criptografar ou 2 para decriptografar.");
                opcao_string = Console.ReadLine();
            }
            int opcao = int.Parse(opcao_string);
            string titulo = opcao == 1 ? "criptografado" : "decriptografado";

            if (opcao == 1)
            {
                Console.WriteLine("Digite por quantos caracteres será feita a criptografia.");
                string troca_string = Console.ReadLine();
                var numerico = int.TryParse(troca_string, out int troca);
                while (!numerico || troca < 1)
                {
                    Console.WriteLine("\r\nResposta inválida!");
                    Console.WriteLine("Digite por quantos caracteres será feita a criptografia/decriptografia.");
                    troca_string = Console.ReadLine();
                    numerico = int.TryParse(troca_string, out troca);
                }

                Console.WriteLine("\r\nDigite o texto para ser criptografado.");
                string texto_original = Console.ReadLine();
                string nome_arquivo = "input.txt";
                File.WriteAllText(nome_arquivo, texto_original);

                string cifra_texto = Caesar(File.ReadAllText(nome_arquivo), troca, opcao == 1 ? 1 : 2);
                File.WriteAllText("output.txt", cifra_texto);
                File.WriteAllText("value.txt", Convert.ToString(troca));
                Console.WriteLine("Texto " + titulo + ".");
            }
            else
            {
                Console.WriteLine("\r\nPara que seus dados sejam resgatados, realize uma transferência de 0.1 BTC para a seguinte carteira: 13j8drfVDJ1YDgWuTepbgbZivx5PmDXwzz");
                Console.WriteLine("\r\nDigite 1 se o pagamento foi realizado.");
                string pag_string = Console.ReadLine();
                while (pag_string != "1")
                {
                    Console.WriteLine("\r\nTente novamente após relizar o pagamento!");
                    return;
                }
                int troca = Convert.ToInt32(File.ReadAllText("value.txt"));
                string cifra_texto = Caesar(File.ReadAllText("output.txt"), troca, 2);
                File.WriteAllText("decrypted.txt", cifra_texto);
                Console.WriteLine("Texto " + titulo + ".");
            }        
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

                    novo_index %= alfabeto.Length;
                    novo_texto += alfabeto.Substring(novo_index, 1);
                }
            }
            return novo_texto;
        }
    }
}