using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Escolha o exercício para executar:");
            Console.WriteLine("1 - Calculadora");
            Console.WriteLine("2 - Soma e Média");
            Console.WriteLine("3 - Controle do Drone");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");

            string opcao = Console.ReadLine();

            if (opcao == "0")
                break;
            else if (opcao == "1")
                Calculadora.Executar();
            else if (opcao == "2")
                Exercicio2.Executar();
            else if (opcao == "3")
                DroneControle.Executar();
            else
            {
                Console.WriteLine("Opção inválida. Pressione Enter para continuar.");
                Console.ReadLine();
            }
        }
    }
}
