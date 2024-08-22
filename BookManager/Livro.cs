using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookMananger
{
    public class Livro
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public int QuantidadeDisponivel { get; set; }

        public Livro(int id, string titulo, string autor, int anoPublicacao, int quantidadeDisponivel)
        {
            ID = id;
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            QuantidadeDisponivel = quantidadeDisponivel;
        }

        public static void Cadastrar(Livro[] livros, ref int contadorLivros)
        {
            Console.WriteLine("Digite a quantidade de livros para cadastrar: ");
            int quantidadeLivros = int.Parse(Console.ReadLine());

            for (int i = 0; i < quantidadeLivros; i++)
            {
                Console.WriteLine($"\nCadastro do livro {i + 1} de {quantidadeLivros}");

                Console.Write("ID do livro: ");
                int id = int.Parse(Console.ReadLine());

                if (Array.Exists(livros, l => l != null && l.ID == id))
                {
                    Console.WriteLine("Erro: Um livro com esse ID já está cadastrado.\n");
                    i--;
                    continue;
                }

                Console.Write("Título do livro: ");
                string titulo = Console.ReadLine();
                Console.Write("Autor do livro: ");
                string autor = Console.ReadLine();
                Console.Write("Ano de publicação: ");
                int anoPublicacao = int.Parse(Console.ReadLine());
                Console.Write("Quantidade disponível: ");
                int quantidadeDisponivel = int.Parse(Console.ReadLine());

                livros[contadorLivros++] = new Livro(id, titulo, autor, anoPublicacao, quantidadeDisponivel);
                Console.WriteLine("Livro cadastrado com sucesso!\n");
            }
        }

        public static void ExibirQuantidadeLivros(Livro[] livros, int contadorLivros)
        {
            if (contadorLivros == 0)
            {
                Console.WriteLine("Não há livros cadastrados!");
            }
            else
            {
                for (int i = 0; i < contadorLivros; i++)
                {
                    Console.WriteLine($"ID {livros[i].ID} | Título: {livros[i].Titulo}, Quantidade Disponível: {livros[i].QuantidadeDisponivel}");
                }
            }
            Console.WriteLine();
        }
    }
}
