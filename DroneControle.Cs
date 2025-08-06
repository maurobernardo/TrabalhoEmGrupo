using System;

public static class DroneControle
{
    private static Drone drone = new Drone();

    public static void Executar()
    {
        bool sair = false;

        while (!sair)
        {
            Console.Clear();
            drone.MostrarStatus();

            Console.WriteLine("Menu de controle do drone:");
            Console.WriteLine("1 - Definir altura");
            Console.WriteLine("2 - Subir 0,5m");
            Console.WriteLine("3 - Descer 0,5m");
            Console.WriteLine("4 - Definir direção");
            Console.WriteLine("5 - Girar direção para direita 5º");
            Console.WriteLine("6 - Girar direção para esquerda 5º");
            Console.WriteLine("7 - Aumentar velocidade 0,5 m/s");
            Console.WriteLine("8 - Diminuir velocidade 0,5 m/s");
            Console.WriteLine("9 - Aproximar objeto");
            Console.WriteLine("10 - Distanciar objeto");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "0":
                    sair = true;
                    break;
                case "1":
                    Console.Write("Informe a altura desejada (0,5 a 25 m): ");
                    if (double.TryParse(Console.ReadLine(), out double alt))
                        drone.DefinirAltura(alt);
                    else
                        Console.WriteLine("Valor inválido.");
                    break;
                case "2":
                    drone.Subir();
                    break;
                case "3":
                    drone.Descer();
                    break;
                case "4":
                    Console.Write("Informe a direção (0º a 360º): ");
                    if (int.TryParse(Console.ReadLine(), out int dir))
                        drone.DefinirDirecao(dir);
                    else
                        Console.WriteLine("Valor inválido.");
                    break;
                case "5":
                    drone.GirarDireita();
                    break;
                case "6":
                    drone.GirarEsquerda();
                    break;
                case "7":
                    drone.AumentarVelocidade();
                    break;
                case "8":
                    drone.DiminuirVelocidade();
                    break;
                case "9":
                    drone.AproximarObjeto();
                    break;
                case "10":
                    drone.DistanciarObjeto();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}

class Drone
{
    public double Altura { get; private set; } = 0.5;
    public int Direcao { get; private set; } = 0;
    public double Velocidade { get; private set; } = 0;
    public bool Aproximado { get; private set; } = false;

    const double ALTURA_MIN = 0.5;
    const double ALTURA_MAX = 25.0;
    const double VELOCIDADE_MIN = 0.0;
    const double VELOCIDADE_MAX = 15.0;

    public void DefinirAltura(double altura)
    {
        if (Aproximado)
        {
            Console.WriteLine("Não pode mudar altura estando próximo a um objeto.");
            return;
        }

        if (altura >= ALTURA_MIN && altura <= ALTURA_MAX)
        {
            Altura = altura;
            Console.WriteLine($"Altura definida para {Altura} metros.");
        }
        else
        {
            Console.WriteLine($"Altura inválida. Deve estar entre {ALTURA_MIN} e {ALTURA_MAX} metros.");
        }
    }

    public void Subir()
    {
        if (Aproximado)
        {
            Console.WriteLine("Não pode mudar altura estando próximo a um objeto.");
            return;
        }

        if (Altura + 0.5 <= ALTURA_MAX)
        {
            Altura += 0.5;
            Console.WriteLine($"Altura aumentada para {Altura} metros.");
        }
        else
        {
            Console.WriteLine("Já está na altura máxima.");
        }
    }

    public void Descer()
    {
        if (Aproximado)
        {
            Console.WriteLine("Não pode mudar altura estando próximo a um objeto.");
            return;
        }

        if (Altura - 0.5 >= ALTURA_MIN)
        {
            Altura -= 0.5;
            Console.WriteLine($"Altura diminuída para {Altura} metros.");
        }
        else
        {
            Console.WriteLine("Já está na altura mínima.");
        }
    }

    public void DefinirDirecao(int angulo)
    {
        if (Aproximado)
        {
            Console.WriteLine("Não pode mudar direção estando próximo a um objeto.");
            return;
        }

        if (angulo >= 0 && angulo <= 360)
        {
            Direcao = angulo;
            Console.WriteLine($"Direção definida para {Direcao}º.");
        }
        else
        {
            Console.WriteLine("Direção inválida. Informe um ângulo entre 0º e 360º.");
        }
    }

    public void GirarDireita()
    {
        if (Aproximado)
        {
            Console.WriteLine("Não pode mudar direção estando próximo a um objeto.");
            return;
        }

        Direcao = (Direcao + 5) % 360;
        Console.WriteLine($"Direção girada para a direita: {Direcao}º.");
    }

    public void GirarEsquerda()
    {
        if (Aproximado)
        {
            Console.WriteLine("Não pode mudar direção estando próximo a um objeto.");
            return;
        }

        Direcao -= 5;
        if (Direcao < 0) Direcao += 360;
        Console.WriteLine($"Direção girada para a esquerda: {Direcao}º.");
    }

    public void AumentarVelocidade()
    {
        if (Velocidade + 0.5 <= VELOCIDADE_MAX)
        {
            Velocidade += 0.5;
            Console.WriteLine($"Velocidade aumentada para {Velocidade} m/s.");
        }
        else
        {
            Console.WriteLine("Já está na velocidade máxima.");
        }
    }

    public void DiminuirVelocidade()
    {
        if (Velocidade - 0.5 >= VELOCIDADE_MIN)
        {
            Velocidade -= 0.5;
            Console.WriteLine($"Velocidade diminuída para {Velocidade} m/s.");
        }
        else
        {
            Console.WriteLine("Já está parado.");
        }
    }

    public void AproximarObjeto()
    {
        if (Velocidade > 0)
        {
            Console.WriteLine("Para aproximar de um objeto, o drone deve estar parado (0 m/s).");
            return;
        }

        if (Aproximado)
        {
            Console.WriteLine("Drone já está próximo do objeto.");
            return;
        }

        Aproximado = true;
        Console.WriteLine("Drone aproximou-se do objeto com sucesso.");
    }

    public void DistanciarObjeto()
    {
        if (!Aproximado)
        {
            Console.WriteLine("Drone não está próximo de nenhum objeto.");
            return;
        }

        Aproximado = false;
        Console.WriteLine("Drone distanciou-se do objeto e voltou às funções normais.");
    }

    public void MostrarStatus()
    {
        Console.WriteLine("Status do Drone:");
        Console.WriteLine($"Altura: {Altura} m");
        Console.WriteLine($"Direção: {Direcao}º");
        Console.WriteLine($"Velocidade: {Velocidade} m/s - {(Velocidade > 0 ? "Em movimento" : "Sem movimento")}");
        Console.WriteLine($"Próximo de objeto: {(Aproximado ? "Sim" : "Não")}");
        Console.WriteLine();
    }
}
