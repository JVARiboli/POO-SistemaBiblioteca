using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMananger
{
    public class Leitor
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public int QuantidadeEmprestimos { get; set; }
        public int Idade { get; set; }

        public Leitor(string cpf, string nome, int idade)
        {
            CPF = cpf;
            Nome = nome;
            Idade = idade;
            QuantidadeEmprestimos = 0;
        }

        public static void Cadastrar(Leitor[] leitores, ref int contadorLeitores)
        {
            Console.WriteLine("Digite a quantidade de pessoas para cadastrar: ");
            int quantidadeLeitores = int.Parse(Console.ReadLine());

            for (int i = 0; i < quantidadeLeitores; i++)
            {
                Console.WriteLine($"\nCadastro do leitor {i + 1} de {quantidadeLeitores}");

                Console.Write("CPF do leitor: (xxx.xxx.xxx-xx) ");
                string cpf = Console.ReadLine();

                if (Array.Exists(leitores, l => l != null && l.CPF == cpf))
                {
                    Console.WriteLine("Erro: Um leitor com esse CPF já está cadastrado.\n");
                    i--;
                    continue;
                }

                Console.Write("Nome do leitor: ");
                string nome = Console.ReadLine();
                Console.Write("Idade do leitor: ");
                int idade = int.Parse(Console.ReadLine());

                if (idade > 120 || idade < 0)
                {
                    Console.WriteLine("Idade inválida. Tente novamente.");
                    i--;
                    continue;
                }

                leitores[contadorLeitores++] = new Leitor(cpf, nome, idade);
                Console.WriteLine("Leitor cadastrado com sucesso!\n");
            }
        }

        public static void ExibirLeitores(Leitor[] leitores, int contadorLeitores)
        {
            if (contadorLeitores == 0)
            {
                Console.WriteLine("Não há leitores cadastrados!");
            }
            else
            {
                for (int i = 0; i < contadorLeitores; i++)
                {
                    Console.WriteLine($"CPF: {leitores[i].CPF} | Nome: {leitores[i].Nome}, Idade: {leitores[i].Idade} | Quantidade de empréstimos: {leitores[i].QuantidadeEmprestimos}");
                    Console.WriteLine("");
                }
            }
            Console.WriteLine();
        }
    }
}
