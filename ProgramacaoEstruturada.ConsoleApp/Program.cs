using System;
using System.Linq;

namespace ProgramacaoEstruturada.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[5];
            int menorNumero = 0;
            int maiorNumero = 0;
            Console.WriteLine("Programação Estruturada!\n");
            DigitarNumeros(numeros);
            IdentificarMaiorNumero(numeros, ref maiorNumero);
            IdentificarMenorNumero(numeros, out menorNumero);
            double valorMedio = CalcularValorMedio(numeros);
            ExibirNumeros(numeros);

            Console.WriteLine("Maior numero: " + maiorNumero);
            Console.WriteLine("Menor numero: " + menorNumero);
            Console.WriteLine("Valor medio: " + valorMedio);
            EncontrarTresMaioresValores(numeros);
            EncontrarValoresNegativos(numeros);
            RemoverItemDaSequencia(numeros);
        }

        static void RemoverItemDaSequencia(int[] numeros)
        {
            ExibirNumeros(numeros);
            Console.WriteLine("\nEscolha o numero que deseja remover: ");
            int numeroParaRemover = int.Parse(Console.ReadLine());
            for (int i = 0; i < numeros.Length; i++)
            {
                if(numeroParaRemover == numeros[i])
                {
                    numeros = numeros.Where(val => val != numeros[i]).ToArray();
                    break;
                }
            }
            Console.WriteLine("\nSequencia de numeros sem o numero removido: ");
            ExibirNumeros(numeros);
        }

        static void ExibirNumeros(int[] numeros)
        {
            Console.WriteLine("\nExibindo numeros: ");
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write("Numero {0}: {1}\n", i + 1, numeros[i]);
            }
        }

        static void EncontrarValoresNegativos(int[] numeros)
        {
            Console.WriteLine("\nExibindo numeros negativos: ");
            for (int i = 0; i < numeros.Length; i++)
            {
                if(numeros[i] < 0)
                {
                    Console.WriteLine(numeros[i]);
                }
            }
        }

        static void EncontrarTresMaioresValores(int[] numeros)
        {
            Console.WriteLine("Exibindo os 3 maiores valores: ");
            int[] tresMaioresNumeros = new int[3];
            int[] copiaNumeros = new int[numeros.Length];
            numeros.CopyTo(copiaNumeros, 0);

            for (int i = 0; i < tresMaioresNumeros.Length; i++)
            {
                for (int j = 0; j < copiaNumeros.Length; j++)
                {
                    if (copiaNumeros[j] > tresMaioresNumeros[i])
                    {
                        tresMaioresNumeros[i] = copiaNumeros[j];
                    }
                }
                copiaNumeros = copiaNumeros.Where(val => val != tresMaioresNumeros[i]).ToArray();
            }

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Exibindo o {0}º maior numero: {1}\n", i+1, tresMaioresNumeros[i]);
            }
        }

        static double CalcularValorMedio(int[] numeros)
        {
            double valorMedio = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                valorMedio += numeros[i];
            }

            valorMedio /= numeros.Length;

            return valorMedio;
        }

        static void IdentificarMenorNumero(int[] numeros, out int menorNumero)
        {
            menorNumero = numeros[0];
            for (int i = 0; i < numeros.Length; i++)
            {
                if(numeros[i] < menorNumero)
                {
                    menorNumero = numeros[i];
                }
            }
        }

        static void IdentificarMaiorNumero(int[] numeros, ref int maiorNumero)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] > maiorNumero)
                {
                    maiorNumero = numeros[i];
                }
            }
        }

        static void DigitarNumeros(int[] numeros)
        {
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write("Digite o numero {0}: ", i + 1);
                numeros[i] = int.Parse(Console.ReadLine());
            }
        }
    }
}
