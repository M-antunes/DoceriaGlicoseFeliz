using System;
using System.Collections.Generic;

namespace DoceriaGlicoseFeliz
{
    class Program
    {
        static void Main(string[] args)
        {
            //PRODUTOS

            List<Produto> catalogo = new List<Produto>
            {
                new Produto("Marmelada", 1.2),
                new Produto("Bananada", 1.6),
                new Produto("Goiabada", 2.2),
                new Produto("Sonho", 3.1),
                new Produto("Pé de Moloque", 2.9),
                new Produto("Brigadeiro", 2.5),
                new Produto("Cajusinho", 2.5),
                new Produto("Beijinho", 2.2),
                new Produto("Jujuba", 2.2)
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
            string itemEscolhido = "";
            ExibirMenuPrincipal("ver nosso catálogo de doces?");
            string continuarComprando = "s";
            while (continuarComprando == "s")
            {
                double precoDoProduto = 0;
                Console.WriteLine("Qual a quatidade do produto?");
                int qntProduto = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                List<Carrinho> carrinho = new List<Carrinho>();
                carrinho.Add(new Carrinho(itemEscolhido, precoDoProduto, qntProduto));
                Console.WriteLine("Item adicionado ao carrinho.");
                Console.WriteLine("Deseja continuar comprando?");
                Console.WriteLine("s > para sim");
                Console.WriteLine("n > para não");
                continuarComprando = (Console.ReadLine());
                switch (continuarComprando)
                {
                    case "s":                    
                        ExibirMenuPrincipal("ver novamente nosso catálogo?");
                        break;
                    default:
                        if (qntProduto <= 1)
                        {
                            Console.WriteLine($"Seu carrinho contém 1 item: {itemEscolhido}");
                        }
                        else
                        {
                            Console.WriteLine($"Seu carrinho contém {carrinho[2]} itens: {carrinho.ToArray()}");
                        }
                        break;
                }
                
            }
           





            //FUNÇÕES
            void ExibirMenuPrincipal(string message)
            {
                Console.WriteLine($"Deseja {message}?");
                Console.WriteLine("Para sim, digite > 1");
                Console.WriteLine("Para não, digite > 2");
                int continuar = Convert.ToInt32(Console.ReadLine());
                if (continuar == 1)
                {
                    foreach (Produto todoCatalogo in catalogo)
                    {
                        Console.WriteLine(todoCatalogo.ExibirProdutos());
                    }

                    Console.WriteLine("Qual de nossos produtos você deseja comprar?");
                    itemEscolhido = Console.ReadLine();
                }
                else if (continuar == 2)
                {
                    Console.WriteLine("Qual de nossos produtos você deseja comprar?");
                    itemEscolhido = Console.ReadLine();
                }
                    else
                {
                    MostrarErro();
                }
            }

            void MostrarErro()
            {
                Console.WriteLine("Opção que você digitou não existe.");
                Console.WriteLine("Digite uma opção válida");

                foreach (Produto todoCatalogo in catalogo)
                {
                    Console.WriteLine(todoCatalogo.ExibirProdutos());
                }
                Console.WriteLine("Qual de nossos produtos você deseja comprar?");
            }

           
                
                
            
        }

        


        

        
    }
}
