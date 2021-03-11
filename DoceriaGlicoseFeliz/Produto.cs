namespace DoceriaGlicoseFeliz
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Id { get; set; }
        public int Quantidade { get; set; }

        public Produto(int id, string nome, double preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }

        public string ExibirProdutos()
        {
            return $"{Id} - {Nome}";
        }
    }
}
