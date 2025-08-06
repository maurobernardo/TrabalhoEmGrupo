using System;

public static class Calculadora
{
    public static void Executar()
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
            Console.WriteLine("0 - Voltar");
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

            Console.Write("Digite o primeiro valor: ");
            if (!double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.WriteLine("Valor inválido! Pressione Enter para tentar novamente.");
                Console.ReadLine();
                continue;
            }

            Console.Write("Digite o segundo valor: ");
            if (!double.TryParse(Console.ReadLine(), out double num2))
            {
                Console.WriteLine("Valor inválido! Pressione Enter para tentar novamente.");
                Console.ReadLine();
                continue;
            }

            switch (escolha)
            {
                case 1:
                    Console.WriteLine($"Resultado: {num1 + num2}");
                    break;
                case 2:
                    Console.WriteLine($"Resultado: {num1 - num2}");
                    break;
                case 3:
                    Console.WriteLine($"Resultado: {num1 * num2}");
                    break;
                case 4:
                    if (num2 == 0)
                        Console.WriteLine("Não é possível dividir por zero.");
                    else
                        Console.WriteLine($"Resultado: {num1 / num2}");
                    break;
                case 5:
                    if (num2 == 0)
                        Console.WriteLine("Não é possível dividir por zero.");
                    else
                        Console.WriteLine($"Resto da divisão: {num1 % num2}");
                    break;
                case 6:
                    Console.WriteLine($"Resultado: {Math.Pow(num1, num2)}");
                    break;
            }

            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
