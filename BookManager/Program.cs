using System;
using BookMananger;

namespace BookManager
{
    internal class Program
    {
        static Livro[] livros = new Livro[100];
        static Leitor[] leitores = new Leitor[100];
        static Emprestimo[] emprestimos = new Emprestimo[100];

        static int contadorLivros = 0;
        static int contadorLeitores = 0;
        static int contadorEmprestimos = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Cadastrar Leitor");
                Console.WriteLine("2. Cadastrar Livro");
                Console.WriteLine("3. Emprestar Livro");
                Console.WriteLine("4. Calcular Multa");
                Console.WriteLine("5. Exibir Quantidade de Livros Disponíveis");
                Console.WriteLine("6. Exibir Leitores");
                Console.WriteLine("7. Sair");
                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Leitor.Cadastrar(leitores, ref contadorLeitores);
                        break;
                    case 2:
                        Console.Clear();
                        Livro.Cadastrar(livros, ref contadorLivros);
                        break;
                    case 3:
                        Console.Clear();
                        Emprestimo.EmprestarLivro(livros, leitores, emprestimos, contadorLivros, contadorLeitores, ref contadorEmprestimos);
                        break;
                    case 4:
                        Console.Clear();
                        Emprestimo.CalcularMulta(emprestimos, contadorEmprestimos);
                        break;
                    case 5:
                        Console.Clear();
                        Livro.ExibirQuantidadeLivros(livros, contadorLivros);
                        break;
                    case 6:
                        Console.Clear();
                        Leitor.ExibirLeitores(leitores, contadorLeitores);
                        break;
                    case 7:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
