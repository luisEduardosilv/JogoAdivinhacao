using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JogoAdivinhacao.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int numeroAleatorio = random.Next(1, 21);
            int limite = 0;
            int tentativaAtual = 1;
            int pontuacao = 1000;
            int pontos;

            Console.WriteLine("***************************************");
            Console.WriteLine("* Bem-vindo(a) ao Jogo da Adivinhação *");
            Console.WriteLine("***************************************");
            limite = menuDificuldade(limite);


            while (tentativaAtual <= limite)
            {

                Console.WriteLine($"\nTentativa {tentativaAtual} de {limite}");
                Console.WriteLine("----------------------------------------");
                Console.Write($"Qual o seu {tentativaAtual}° chute? ");
                int numeroChutado = Convert.ToInt32(Console.ReadLine());

                if (numeroChutado < numeroAleatorio)
                {
                    pontos = calculaPontuacao(numeroAleatorio, ref pontuacao, numeroChutado);
                    Console.WriteLine($"\nSeu chute foi menor que o número secreto!");
                    Console.WriteLine($"Você fez {pontuacao} pontos!");
                    tentativaAtual++;
                }
                else if (numeroChutado > numeroAleatorio)
                {
                    pontos = calculaPontuacao(numeroAleatorio, ref pontuacao, numeroChutado);
                    Console.WriteLine($"\nSeu chute foi maior que o número secreto!");
                    Console.WriteLine($"Você fez {pontuacao} pontos!");
                    tentativaAtual++;
                }
                else if (numeroChutado == numeroAleatorio)
                {
                    Console.WriteLine("\nParabéns! Você acertou o número secreto");
                    Console.WriteLine($"Você fez {pontuacao} pontos!");
                    break;
                }
                if (tentativaAtual > limite)
                {
                    Console.WriteLine("\nVocê perdeu! Suas tentativas acabaram :(");
                    Console.WriteLine($"Você fez {pontuacao} pontos!");
                }

            }

            Console.ReadLine();
        }

        private static int calculaPontuacao(int numeroAleatorio, ref int pontuacao, int numeroChutado)
        {
            int pontos = (numeroChutado - numeroAleatorio) / 2;
            if (pontos < 1)
            {
                pontos++;
            }
            pontuacao -= Math.Abs(pontos);
            return pontos;
        }

        private static int menuDificuldade(int limite)
        {
            Console.WriteLine("Escolha o nível de dificuldade: \n(1) Fácil  (2) Médio  (3) Difícil");
            Console.Write("Escolha: ");
            int dificuldade = Convert.ToInt32(Console.ReadLine());
            switch (dificuldade)
            {
                case 1:
                    limite = 15;
                    break;
                case 2:
                    limite = 10;
                    break;
                case 3:
                    limite = 5;
                    break;
            }

            return limite;
        }
    }
}