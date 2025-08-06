using System;

class Program
{
    static void Main()
    {
        bool sair = false;

        while (!sair)
        {
            Console.Clear();
            Console.WriteLine("Calculadora - Menu");
            Console.WriteLine("1 - Somar");
            Console.WriteLine("2 - Subtrair");
            Console.WriteLine("3 - Multiplicar");
            Console.WriteLine("4 - Dividir");
            Console.WriteLine("5 - Resto da Divisão");
            Console.WriteLine("6 - Potenciação");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            if (opcao == "0")
            {
                sair = true;
                continue;
            }

            if (!int.TryParse(opcao, out int escolha) || escolha < 0 || escolha > 6)
            {
                Console.WriteLine("Opção inválida! Pressione Enter para tentar novamente.");
                Console.ReadLine();
                continue;
            }

            double num1 = 0, num2 = 0;

            if (escolha >= 1 && escolha <= 6)
            {
                Console.Write("Digite o primeiro valor: ");
                while (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.Write("Valor inválido! Digite um número válido: ");
                }

                Console.Write("Digite o segundo valor: ");
                while (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.Write("Valor inválido! Digite um número válido: ");
                }
            }

            double resultado = 0;
            bool erro = false;

            switch (escolha)
            {
                case 1:
                    resultado = num1 + num2;
                    Console.WriteLine($"Resultado da soma: {resultado}");
                    break;
                case 2:
                    resultado = num1 - num2;
                    Console.WriteLine($"Resultado da subtração: {resultado}");
                    break;
                case 3:
                    resultado = num1 * num2;
                    Console.WriteLine($"Resultado da multiplicação: {resultado}");
                    break;
                case 4:
                    if (num2 == 0)
                    {
                        Console.WriteLine("Não é possível dividir por zero.");
                        erro = true;
                    }
                    else
                    {
                        resultado = num1 / num2;
                        Console.WriteLine($"Resultado da divisão: {resultado}");
                    }
                    break;
                case 5:
                    if (num2 == 0)
                    {
                        Console.WriteLine("Não é possível dividir por zero.");
                        erro = true;
                    }
                    else
                    {
                        resultado = num1 % num2;
                        Console.WriteLine($"Resto da divisão: {resultado}");
                    }
                    break;
                case 6:
                    resultado = Math.Pow(num1, num2);
                    Console.WriteLine($"{num1} elevado a {num2} = {resultado}");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    erro = true;
                    break;
            }

            if (!erro)
                Console.WriteLine("Pressione Enter para voltar ao menu.");

            Console.ReadLine();
        }
    }
}
