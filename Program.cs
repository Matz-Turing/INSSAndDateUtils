using System;

namespace ProjetoExercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Detalhar Data");
                Console.WriteLine("2 - Calcular Desconto INSS");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        DetalharData();
                        break;
                    case "2":
                        CalcularDescontoINSS();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void DetalharData()
        {
            Console.Write("Digite uma data (dd/MM/yyyy): ");
            string dataInput = Console.ReadLine();
            
            if (DateTime.TryParse(dataInput, out DateTime data))
            {
                string diaSemana = data.ToString("dddd");
                string mesExtenso = data.ToString("MMMM");

                Console.WriteLine($"Dia da Semana: {diaSemana}");
                Console.WriteLine($"Mês: {mesExtenso}");

                if (diaSemana.Equals("domingo", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Hora atual: {DateTime.Now:HH:mm}");
                }
            }
            else
            {
                Console.WriteLine("Data inválida.");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        static void CalcularDescontoINSS()
        {
            Console.Write("Digite o valor do salário: ");
            string salarioInput = Console.ReadLine();

            if (decimal.TryParse(salarioInput, out decimal salario))
            {
                decimal inss = 0;

                if (salario <= 1212.00m)
                {
                    inss = salario * 0.075m;
                }
                else if (salario <= 2427.35m)
                {
                    inss = (1212.00m * 0.075m) + ((salario - 1212.00m) * 0.09m);
                }
                else if (salario <= 3641.03m)
                {
                    inss = (1212.00m * 0.075m) + ((2427.35m - 1212.00m) * 0.09m) + ((salario - 2427.35m) * 0.12m);
                }
                else if (salario <= 7087.22m)
                {
                    inss = (1212.00m * 0.075m) + ((2427.35m - 1212.00m) * 0.09m) + ((3641.03m - 2427.35m) * 0.12m) + ((salario - 3641.03m) * 0.14m);
                }
                else
                {
                    inss = (1212.00m * 0.075m) + ((2427.35m - 1212.00m) * 0.09m) + ((3641.03m - 2427.35m) * 0.12m) + ((7087.22m - 3641.03m) * 0.14m);
                }

                decimal salarioLiquido = salario - inss;

                Console.WriteLine($"INSS a pagar: {inss:C}");
                Console.WriteLine($"Salário com desconto do INSS: {salarioLiquido:C}");
            }
            else
            {
                Console.WriteLine("Valor de salário inválido.");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
