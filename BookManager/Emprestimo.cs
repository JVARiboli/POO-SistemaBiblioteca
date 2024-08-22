using BookMananger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager
{
    public class Emprestimo
    {
        public Livro LivroEmprestado { get; set; }
        public Leitor Leitor { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public Emprestimo(Livro livroEmprestado, Leitor leitor, DateTime dataDevolucao)
        {
            LivroEmprestado = livroEmprestado;
            Leitor = leitor;
            DataDevolucao = dataDevolucao;
            DataEmprestimo = DateTime.Now;

            livroEmprestado.QuantidadeDisponivel--;
            leitor.QuantidadeEmprestimos++;
        }

        public static void EmprestarLivro(Livro[] livros, Leitor[] leitores, Emprestimo[] emprestimos, int contadorLivros, int contadorLeitores, ref int contadorEmprestimos)
        {
            Console.Write("CPF do leitor: (xxx.xxx.xxx-xx) ");
            string cpf = Console.ReadLine();
            Leitor leitor = Array.Find(leitores, l => l != null && l.CPF.Equals(cpf, StringComparison.OrdinalIgnoreCase));

            if (leitor == null)
            {
                Console.WriteLine("Leitor não encontrado.\n");
                return;
            }

            Console.Write("ID do livro: ");
            int idLivro = int.Parse(Console.ReadLine());
            Livro livro = Array.Find(livros, l => l != null && l.ID == idLivro);

            if (livro == null || livro.QuantidadeDisponivel == 0)
            {
                Console.WriteLine("Livro não disponível ou não encontrado.\n");
                return;
            }

            Console.Write("Data de devolução (dd/MM/yyyy): ");
            DateTime dataDevolucao = DateTime.Parse(Console.ReadLine());

            emprestimos[contadorEmprestimos++] = new Emprestimo(livro, leitor, dataDevolucao);
            Console.WriteLine("Livro emprestado com sucesso!\n");
        }

        public double CalcularMulta()
        {
            const double VALOR_MULTA_DIARIO = 1.00;
            int diasAtraso = (DateTime.Now - DataDevolucao).Days;

            return diasAtraso > 0 ? diasAtraso * VALOR_MULTA_DIARIO : 0;
        }

        public static void CalcularMulta(Emprestimo[] emprestimos, int contadorEmprestimos)
        {
            Console.Write("CPF do leitor: (xxx-xxx-xxx.xx) ");
            string cpf = Console.ReadLine();
            Emprestimo emprestimo = Array.Find(emprestimos, e => e != null && e.Leitor.CPF.Equals(cpf, StringComparison.OrdinalIgnoreCase));

            if (emprestimo == null)
            {
                Console.WriteLine("Nenhum empréstimo encontrado para este leitor.\n");
                return;
            }

            double multa = emprestimo.CalcularMulta();
            Console.WriteLine(multa > 0 ? $"Multa devida: R${multa:F2}\n" : "Nenhuma multa devida.\n");
        }
    }
}
