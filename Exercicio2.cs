using System;
using System.Collections.Generic;

public class Exercicio2
{
    public static void Executar()
    {
        Console.Clear();
        Console.WriteLine("=== EXERCÍCIO 2: SOMA E MÉDIA ===");

        int quantidade;
        do
        {
            Console.Write("Quantos números deseja informar? (mínimo 3, máximo 10): ");
        }
        while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 3 || quantidade > 10);

        List<double> numeros = new List<double>();

        for (int i = 0; i < quantidade; i++)
        {
            double valor;
            Console.Write($"Digite o {i + 1}º número: ");
            while (!double.TryParse(Console.ReadLine(), out valor))
            {
                Console.WriteLine("Valor inválido. Tente novamente.");
                Console.Write($"Digite o {i + 1}º número: ");
            }
            numeros.Add(valor);
        }

        double soma = 0;
        foreach (double num in numeros)
        {
            soma += num;
        }

        double media = soma / quantidade;

        Console.WriteLine($"\nSoma: {soma}");
        Console.WriteLine($"Média: {media}");

        Console.WriteLine("\nPressione Enter para voltar ao menu...");
        Console.ReadLine();
    }
}
