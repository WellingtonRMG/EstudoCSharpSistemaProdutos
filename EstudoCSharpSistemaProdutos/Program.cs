using System.Globalization;

class Program
{
    static void Main()
    {
        Produto[] produtos = new Produto[2];
       
        for (int i = 0; i < produtos.Length; i++)
        {
            int numeroDeProduto = i + 1;
            produtos[i] = new Produto();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n--- CADASTRO DO PRODUTO {numeroDeProduto} ---");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Digite o nome do produto: ");
            Console.ResetColor();
            string nomeItem = Console.ReadLine();
            produtos[i].AtribuirNome(nomeItem);
            produtos[i].valor = ObterValor(produtos[i].nome);
            produtos[i].estoque = ObterEstoque(produtos[i].nome);

            Console.Clear();
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t=== PRODUTOS CADASTRADOS NO ESTOQUE ===");
        Console.ResetColor();
        foreach (var p in produtos)
        {
            Console.WriteLine($"\nNome: {p.nome}");
            Console.WriteLine($"Preço: R$ {p.valor.ToString("F2", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Estoque: {p.estoque} unidades");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------");
            Console.ResetColor();
        }
    }
    class Produto()
    {
        public string nome { get; private set; }
        public double valor { get; set; } = 0;
        public int estoque { get; set; } = 0;

        public void AtribuirNome(string NovoNome)
        {

            if (!string.IsNullOrEmpty(NovoNome))
            {
                nome = NovoNome;
            }

        }
    }
    static double ObterValor(string nomeProduto)
    {
        while (true)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"Digite o valor de {nomeProduto}: ");
                Console.ResetColor();
                CultureInfo ptBr = new CultureInfo("pt-BR");
                double valorDigitado = Convert.ToDouble(Console.ReadLine(), ptBr);

                if (valorDigitado < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return valorDigitado;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ERRO] Digite apenas números válidos!");
                Console.ResetColor();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ERRO] Não é permitido número negativos!");
                Console.ResetColor();
            }
        }
    }
    static int ObterEstoque(string nomeProduto)
    {
        while (true)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"Digite a quantidade em estoque de {nomeProduto}: ");
                Console.ResetColor();
                int qtdEstoque = Convert.ToInt32(Console.ReadLine());

                if (qtdEstoque < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return qtdEstoque;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ERRO] Digite apenas números válidos!");
                Console.ResetColor();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("[ERRO] Não é permitido número negativos!");
                Console.ResetColor();
            }
        }
    }
}