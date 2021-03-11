using System;
using System.Collections.Generic;
using System.Linq;

namespace DoceriaGlicoseFeliz
{
    class Program
    {
        static void Main(string[] args)
        {
            //PRODUTOS

            List<Produto> catalogo = new List<Produto>
            {
                new Produto(1, "Marmelada", 1.2),
                new Produto(2, "Bananada", 1.6),
                new Produto(3, "Goiabada", 2.2),
                new Produto(4, "Sonho", 3.1),
                new Produto(5, "Pé de Moloque", 2.9),
                new Produto(6, "Brigadeiro", 2.5),
                new Produto(7, "Cajuzinho", 2.5),
                new Produto(8, "Beijinho", 2.2),
                new Produto(9, "Jujuba", 2.2)
            };

            //FUNCIONÁRIOS

            List<Funcionario> funcionario = new List<Funcionario>
            {
                new Funcionario("Marivaldo"),
                new Funcionario("Helena"),
                new Funcionario("Jucimara")
            };

            //LÓGICA
            Console.WriteLine("Bem vindo a Doceria Glicose Feliz!");
            bool continuarComprando = true;
            List<Produto> carrinho = new List<Produto>();
            while (continuarComprando)
            {
                Produto itemEscolhido = ExibirMenuPrincipal(catalogo);
                Console.WriteLine("Qual a quatidade do produto?");
                itemEscolhido.Quantidade = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                carrinho.Add(itemEscolhido);
                Console.WriteLine("Item adicionado ao carrinho.");
                Console.WriteLine("Deseja continuar comprando?");
                Console.WriteLine("s > para sim");
                Console.WriteLine("n > para não");
                _ = Console.ReadLine() == "s" ? continuarComprando = true : continuarComprando = false;
            }

            foreach (var item in carrinho)
            {
                Console.WriteLine($"Seu carrinho contém {item.Nome}");
                Console.WriteLine($"Quantidade: {item.Quantidade}");
            }

        }


            //FUNÇÕES
            static Produto ExibirMenuPrincipal(List<Produto> produtos)
            {
            
            int id;
            foreach (Produto todoCatalogo in produtos)
            {
                Console.WriteLine(todoCatalogo.ExibirProdutos());
            }
            Console.WriteLine("Digite o número correspondete ao produto que você deseja comprar?");
            id = Convert.ToInt32(Console.ReadLine());
            //var resultado = produtos.Where(x => x.Id == id).ToList();
            var resultado = produtos.Find(x => x.Id == id);
            
            if (resultado == null)
            {
                MostrarErro();
                return ExibirMenuPrincipal(produtos);
            }
                return resultado;
            }

            static void MostrarErro()
            {
                Console.WriteLine("A Opção que você digitou não existe.");
                Console.WriteLine("Digite uma opção válida");
                
            }

           
                
                
            
        

        


        

        
    }
}
