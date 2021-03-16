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
           
            List<Funcionario> funcionarios = new List<Funcionario>
            {
                new Funcionario("Marivaldo", 1),
                new Funcionario("Helena", 2),
                new Funcionario("Jucimara", 3),
                new Funcionario("Maria", 4)
            };


            //LÓGICA
            Console.WriteLine("***************************");
            Console.WriteLine("Bem vindo a Doceria Glicose Feliz!");
            Console.WriteLine("***************************");
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
                Console.WriteLine("Para continuar comprando digite > (s) ?");
                _ = Console.ReadLine() == "s" ? continuarComprando = true : continuarComprando = false;
            }

            Console.WriteLine($"Seu carrinho contém:");

            double precoFinal = 0;
            
            foreach (var item in carrinho)
            {
                var soma = item.Preco * item.Quantidade;
                Console.WriteLine($"{item.Quantidade} unidades de {item.Nome} - R${soma}");
                precoFinal += soma;
            }
           
            Console.WriteLine("");
            Console.Write($"O valor total de sua compra é de: R${precoFinal:0.00}");
            Console.WriteLine("");

            //ATENDIMENTO

            var aleatorio = new Random();
            int id = aleatorio.Next(funcionarios.Count);
            var atendente = funcionarios.Find(x => x.Id == id);
            Console.Write($"Você será atendido pelo funcionario: ");
            Console.WriteLine(atendente.Nome.ToUpper());
            Console.WriteLine("");
            Console.WriteLine("Pressione qualquer tecla para continuar para a forma de pagamento");
            Console.ReadLine();
            Console.Clear();
            ExibirPagamento(precoFinal);
            Console.WriteLine("***************************");
            Console.WriteLine("A Doceria Glicose Feliz agradece sua compra.");
            Console.WriteLine("Tenha um bom dia.");
            Console.WriteLine("E volte sempre");
            Console.WriteLine("***************************");
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
                Console.Clear();
                Console.WriteLine("A Opção que você digitou não existe.");
                Console.WriteLine("Digite uma opção válida");
                
            }

            static void ExibirPagamento(double precoTotal)
            {
            Console.WriteLine("Selecione a forma de pagamento");
            Console.WriteLine("Digite <1> para obter disconto de 3% com pagamento à vista.");
            Console.WriteLine("Digite <2> para pagar com cartão (acréscimo de 5% no valor total)");
            int formaDePagamento = Convert.ToInt32(Console.ReadLine());
            switch (formaDePagamento)
            {
                case 1:
                    {
                        double desconto = precoTotal - (precoTotal * 3) / 100;
                        Console.WriteLine($"O preço de sua compra à vista é de: R${desconto:0.00}");
                    }
                    break;
                case 2:
                    {
                        double acrescimo = precoTotal + (precoTotal * 5) / 100;
                        Console.WriteLine($"O preço de sua compra no cartão é de: R${acrescimo:0.00}");
                        if (precoTotal > 50)
                        {
                            Console.WriteLine("É possível parcelar em até 3x compras acima de 50 reais");
                            Console.WriteLine("Se houver interesse, digite 1");
                            int interesse = Convert.ToInt32(Console.ReadLine());
                            if (interesse == 1)
                            {
                                Console.WriteLine("Em quantas vezes gostaria de parcelar a compra?");
                                int parcelas = Convert.ToInt32(Console.ReadLine());
                                double valorParcelado = precoTotal / parcelas;
                                Console.WriteLine($"O valor R${precoTotal:0.00} ficou parcelado em {parcelas} parcelas de R${valorParcelado:0.00}");
                            }
                        }
                    }
                    break;
                default:
                    {
                        MostrarErro();
                        ExibirPagamento(precoTotal);
                    }
                    break;
            }
            }
            














    }
}
